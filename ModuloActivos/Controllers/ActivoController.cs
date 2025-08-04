
using ClosedXML.Excel;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using Path = System.IO.Path;


namespace ModuloActivos.Controllers
{
    [Route("Activos")]
    public class ActivosController : Controller
    {
        private readonly ILogger<ActivosController> _logger;

        public ActivosController(ILogger<ActivosController> logger)
        {
            _logger = logger;
        }
        public bool SetContextUserMenu()
        {
            var muserMenu = HttpContext.Session.GetString("userMenu");
            string musuario = HttpContext.Session.GetString("muser");

            //ViewBag.UserMenu = HttpContext.Session.GetString("userMenu");

            bool mretorno = false;
            if (!string.IsNullOrEmpty(muserMenu) && !string.IsNullOrEmpty(musuario)) {
                ViewBag.UserMenu = JsonSerializer.Deserialize<List<IntranetFM.Modelos.MenuItem>>(muserMenu);
                mretorno = true;
            }
            return mretorno;
        }
     
        // GET: ActivosController
        [HttpGet]
        [Route("/Activos/Listar")]
        public IActionResult Listar(string pchecked = "")
        {
            try
            {

                if (pchecked == "")
                {
                    HomeController homeController = new HomeController();
                    IntranetFM.Utilitarios.WriteLog(new IntranetFM.Modelos.ApplicationLog { _action = "Entra en Activos/Listar y va a verificar la autenticacion", _ipaddress = IntranetFM.Utilitarios.GetIPAddress(HttpContext), _user = "user null" });
                    return homeController.checkAutenticationStatus("Activos", "Listar", HttpContext);
                }


                //var muserMenu = HttpContext.Session.GetString("userMenu");
                //string musuario = HttpContext.Session.GetString("muser");

                //if (!string.IsNullOrEmpty(muserMenu) && !string.IsNullOrEmpty(musuario))
                if (SetContextUserMenu())
                {
                    //SetContextUserMenu();
                    //ViewBag.UserMenu = JsonSerializer.Deserialize<List<IntranetFM.Modelos.MenuItem>>(muserMenu);

                    // Verificación de sesión y permisos
                    //var muserMenu = HttpContext.Session.GetString("userMenu");
                    /*if (string.IsNullOrEmpty(muserMenu))
                    {
                        return RedirectToAction("Login", "Account"); // Ajusta según tu flujo de autenticación
                    }*/

                    // Cargar menú de aplicaciones
                    //ViewBag.Apps = JsonSerializer.Deserialize<List<MenuItem>>(muserMenu);

                    // Obtener lista de activos con relaciones completas
                    IntranetFM.Class.Activos clsActivos;
                    List<IntranetFM.Modelos.Activo> listaActivos;
                    try
                    {
                        clsActivos = new IntranetFM.Class.Activos();
                        listaActivos = clsActivos.Query(new IntranetFM.Modelos.Activo { _id = 0 });

                    }
                    catch (Exception ex)
                    {
                        IntranetFM.Utilitarios.WriteLog(new IntranetFM.Modelos.ApplicationLog { _action = "ERROR: " + ex.Message });
                        return View("Index", new List<IntranetFM.Modelos.Activo>());
                        //throw;
                    }

                    // Cargar datos relacionados para cada activo
                    if (listaActivos != null)
                    {
                        IntranetFM.Class.Marcas clsMarcas = new IntranetFM.Class.Marcas();
                        IntranetFM.Class.Ubicaciones clsUbicaciones = new IntranetFM.Class.Ubicaciones();
                    var clsPersonas= new IntranetFM.Class.Personas();

                    foreach (IntranetFM.Modelos.Activo activo in listaActivos)
                    {
                        activo._marca = clsMarcas.GetById(activo._marca._rowid);
                        //Console.WriteLine(activo._marca._marca);
                        activo._ubicacion = clsUbicaciones.GetById(activo._ubicacion._rowid);
                        if (activo._responsable._rowid != 0)
                        {
                            activo._responsable = clsPersonas.GetById(activo._responsable._rowid);

                        }
                        
                    }
                }
                CargarListasDesplegables();
                ViewBag.ListaActivos = listaActivos ?? new List<IntranetFM.Modelos.Activo>();

                return View("Index",listaActivos);
                }
                else { return RedirectToAction("Index", "Home"); }

            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Error al deserializar el menú de usuario");
                TempData["ErrorMessage"] = "Error de configuración";
                return View(new List<IntranetFM.Modelos.Activo>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Index de Activos");
                TempData["ErrorMessage"] = "Error al cargar los activos";
                return View(new List<IntranetFM.Modelos.Activo>());
            }
        }
        [HttpGet]
        [Route("/Activos/Exportar")]
        public IActionResult Exportar(
             string tipo,
             int responsable = 0,
             int ubicacion = 0,
             string filtro = "",
             bool ascendente = true,
             string ordenarPor = "",
             string estado = "",
             DateTime? fechaInicio = null,
             DateTime? fechaFin = null)
        {
            var clsActivos = new IntranetFM.Class.Activos();
            var lista = clsActivos.Query(new IntranetFM.Modelos.Activo { _id = 0 });
            string nombreResponsable = "";
            var clsMarcas = new IntranetFM.Class.Marcas();
            var clsUbicaciones = new IntranetFM.Class.Ubicaciones();
            var clsPersonas = new IntranetFM.Class.Personas();

            foreach (var activo in lista)
            {
                if (activo._marca != null)
                    activo._marca = clsMarcas.GetById(activo._marca._rowid);

                if (activo._ubicacion != null)
                    activo._ubicacion = clsUbicaciones.GetById(activo._ubicacion._rowid);

                if (activo._responsable != null && activo._responsable._rowid != 0)
                    activo._responsable = clsPersonas.GetById(activo._responsable._rowid);
            }

            //  Filtro general (texto)
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.ToLower();
                lista = lista.Where(a =>
                    (a._placa?.ToLower().Contains(filtro) ?? false) ||
                    (a._marca?._marca?.ToLower().Contains(filtro) ?? false) ||
                    (a._ubicacion?._ubicacion?.ToLower().Contains(filtro) ?? false) ||
                    (a._descripcion?.ToLower().Contains(filtro) ?? false) ||
                    (a._responsable?._nombre?.ToLower().Contains(filtro) ?? false) ||
                    (a._responsable?._apellido1?.ToLower().Contains(filtro) ?? false)
                ).ToList();
            }

            //  Filtro por responsable
            if (responsable > 0)
            {
                lista = lista.Where(a => a._responsable?._rowid == responsable).ToList();
                var persona = clsPersonas.GetById(responsable);

                if (persona != null)
                    nombreResponsable = $"{persona._nombre} {persona._apellido1}";
            }

            //  Filtro por ubicación
            if (ubicacion > 0)
            {
                lista = lista.Where(a => a._ubicacion?._rowid == ubicacion).ToList();
            }

            //  Filtro por fechas
            if (fechaInicio.HasValue)
            {
                lista = lista.Where(a => a._fechacompra >= fechaInicio.Value).ToList();
            }
            if (fechaFin.HasValue)
            {
                lista = lista.Where(a => a._fechacompra <= fechaFin.Value).ToList();
            }

            //  Filtro por estado
            if (!string.IsNullOrEmpty(estado))
            {
                lista = lista.Where(a => a._estado?.ToLower() == estado.ToLower()).ToList();
            }

            //  Ordenamiento
            if (!string.IsNullOrEmpty(ordenarPor))
            {
                switch (ordenarPor.ToLower())
                {
                    case "descripcion":
                        lista = ascendente ? lista.OrderBy(a => a._descripcion).ToList()
                                    : lista.OrderByDescending(a => a._descripcion).ToList();
                        break;
                    case "placa":
                        lista = ascendente ? lista.OrderBy(a => a._placa).ToList()
                                    : lista.OrderByDescending(a => a._placa).ToList();
                        break;
                    case "ubicacion":
                        lista = ascendente ? lista.OrderBy(a => a._ubicacion?._ubicacion).ToList()
                                    : lista.OrderByDescending(a => a._ubicacion?._ubicacion).ToList();
                        break;
                    case "responsable":
                        lista = ascendente ? lista.OrderBy(a => a._responsable?._nombre).ThenBy(a => a._responsable?._apellido1).ToList()
                                    : lista.OrderByDescending(a => a._responsable?._nombre).ThenByDescending(a => a._responsable?._apellido1).ToList();
                        break;
                }
            }
            //  Exportar
            if (tipo == "pdf")
            {
                var pdfBytes = GenerarPDF(lista, nombreResponsable);
                return File(pdfBytes, "application/pdf", "activos.pdf");
            }
            else if (tipo == "excel")
            {
                var excelBytes = GenerarExcel(lista);
                return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "activos.xlsx");
            }

            return BadRequest("Tipo no soportado");
        }

        private byte[] GenerarExcel(List<IntranetFM.Modelos.Activo> lista)
        {
			using var workbook = new XLWorkbook();
			var worksheet = workbook.Worksheets.Add("Activos");

			// Encabezados
			worksheet.Cell(1, 1).Value = "Descripción";
			worksheet.Cell(1, 2).Value = "Placa";
			worksheet.Cell(1, 3).Value = "Marca";
			worksheet.Cell(1, 4).Value = "Ubicación";
			worksheet.Cell(1, 5).Value = "Responsable";

			// Estilo de encabezado
			var headerRange = worksheet.Range(1, 1, 1, 5);
			headerRange.Style.Font.Bold = true;
			headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
			headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
			headerRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
			headerRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
			headerRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
			headerRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;

			int row = 2;
			foreach (var activo in lista)
			{
				worksheet.Cell(row, 1).Value = activo._descripcion;
				worksheet.Cell(row, 2).Value = activo._placa;
				worksheet.Cell(row, 3).Value = activo._marca?._marca;
				worksheet.Cell(row, 4).Value = activo._ubicacion?._ubicacion;
				worksheet.Cell(row, 5).Value = $"{activo._responsable?._nombre} {activo._responsable?._apellido1}".Trim();
				row++;
			}

			// Aplicar bordes a todas las celdas con datos
			var dataRange = worksheet.Range(1, 1, row - 1, 5);
			dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
			dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

			// Ajustar el ancho automáticamente
			worksheet.Columns().AdjustToContents();

			// Fijar fila de encabezado al hacer scroll
			worksheet.SheetView.FreezeRows(1);

			using var stream = new MemoryStream();
			workbook.SaveAs(stream);
			return stream.ToArray();
		}
		private byte[] GenerarPDF(List<IntranetFM.Modelos.Activo> lista, string nombreResponsable)
		{
			using var stream = new MemoryStream();
			var writer = new PdfWriter(stream);
			var pdf = new PdfDocument(writer);
			var document = new Document(pdf, PageSize.A4.Rotate(), false); // Horizontal

			// Margen y fuente
			document.SetMargins(20, 20, 20, 20);
			var font = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

			// Logo UCR
			var logoUcrPath = "C:\\Users\\bayro\\source\\repos\\ModuloActivos\\wwwroot\\imagenes\\logo-ucr.png";
			var logoUcrImage = new Image(ImageDataFactory.Create(logoUcrPath)).ScaleToFit(150, 150);

			// Logo Facultad Medicina
			var logoMedPath = "C:\\Users\\bayro\\source\\repos\\ModuloActivos\\wwwroot\\imagenes\\logo-facultad-medicina.png";
			var logoMedImage = new Image(ImageDataFactory.Create(logoMedPath)).ScaleToFit(150, 150).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.RIGHT);

			// Título multilínea centrado
			var titulo = new Paragraph()
				.Add("UNIVERSIDAD DE COSTA RICA\n")
				.Add("Facultad de Medicina\n")
				.Add("Decanato: Unidad 70")
				.SetFont(font)
				.SetFontSize(13)
				.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
				.SetMultipliedLeading(1.2f) // espacio entre líneas
				.SetMarginTop(15)
				.SetMarginBottom(10);

			// Encabezado con tres columnas: Logo UCR - Título - Logo Medicina
			var encabezado = new Table(new float[] { 1, 3, 1 }).UseAllAvailableWidth().SetMarginBottom(10);
			encabezado.AddCell(new Cell().Add(logoUcrImage).SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
			encabezado.AddCell(new Cell().Add(logoMedImage).SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE));
			document.Add(encabezado);
            document.Add(titulo);
			var invetarioTexto = new Paragraph()
				.Add("Inventario de Bienes Institucionales")
                .SetFont(font)
				.SetFontSize(13)
				.SimulateBold()
				.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
				.SetMultipliedLeading(1.2f) // espacio entre líneas
				.SetMarginTop(15)
				.SetMarginBottom(10);
			document.Add(invetarioTexto);

            if (!string.IsNullOrEmpty(nombreResponsable))
            {
                document.Add(new Paragraph($"Activos a cargo de {nombreResponsable}")
                .SetFont(font)
                .SetFontSize(13)
                .SimulateBold()
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetMultipliedLeading(1.2f) // espacio entre líneas
                .SetMarginTop(15)
                .SetMarginBottom(10));
            }
            // Tabla de activos
            var table = new Table(new float[] { 4, 2, 2, 2, 3 }).UseAllAvailableWidth();
			var headerColor = new DeviceRgb(0, 74, 143); // Azul UCR
			var headerFontColor = ColorConstants.WHITE;

			// Encabezados
			string[] headers = { "Descripción", "Placa", "Marca", "Ubicación", "Responsable" };
			foreach (var header in headers)
			{
				table.AddHeaderCell(new Cell()
					.Add(new Paragraph(header).SetFont(font).SetFontColor(headerFontColor).SimulateBold())
					.SetBackgroundColor(headerColor)
					.SetTextAlignment(TextAlignment.CENTER)
					.SetPadding(5));
			}

			// Cuerpo
			foreach (var activo in lista)
			{
				table.AddCell(new Cell().Add(new Paragraph(activo._descripcion ?? "")).SetPadding(3));
				table.AddCell(new Cell().Add(new Paragraph(activo._placa ?? "")).SetPadding(3));
				table.AddCell(new Cell().Add(new Paragraph(activo._marca?._marca ?? "")).SetPadding(3));
				table.AddCell(new Cell().Add(new Paragraph(activo._ubicacion?._ubicacion ?? "")).SetPadding(3));
				table.AddCell(new Cell().Add(new Paragraph(
					activo._responsable != null
					? $"{activo._responsable._nombre} {activo._responsable._apellido1}"
					: "No asignado")).SetPadding(3));
			}

			document.Add(table);
			document.Add(new Paragraph("\n\n\n"));

			// Campo para la fecha
			document.Add(new Paragraph("Fecha: ___________________________")
				.SetTextAlignment(TextAlignment.LEFT)
				.SetFontSize(11));

			// Espacio vertical entre fecha y firma
			document.Add(new Paragraph("\n\n\n"));

			// Campo para la firma del responsable
			document.Add(new Paragraph("Firma del responsable: ___________________________________________")
				.SetTextAlignment(TextAlignment.LEFT)
				.SetFontSize(11));
			int totalPages = pdf.GetNumberOfPages();
			for (int i = 1; i <= totalPages; i++)
			{
				var page = pdf.GetPage(i);
				var canvas = new PdfCanvas(page);

				// Número de página a la derecha
				canvas.BeginText()
					.SetFontAndSize(font, 9)
					.MoveText(page.GetPageSize().GetWidth() - 60, 20)
					.ShowText($"Página {i}")
					.EndText();

				// Fecha a la izquierda
				canvas.BeginText()
					.SetFontAndSize(font, 9)
					.MoveText(40, 20)
					.ShowText($"Fecha: {DateTime.Now:dd/MM/yyyy}")
					.EndText();

				canvas.Release();
			}

			document.Close();

			return stream.ToArray();
		}

		[HttpGet]
        [Route("/Activos/Create")]
        public IActionResult Create()
        {
            try
            {
                CargarListasDesplegables();
               
                return View(new IntranetFM.Modelos.Activo
                {
                    _fechacompra = DateTime.Today,
                    _estado = "1" // Activo por defecto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el formulario de creación");
                TempData["ErrorMessage"] = "Error al cargar el formulario";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("/Activos/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection form, IFormFile imagenArchivo, IFormFile documentoArchivo)
        {
            try
            {
                // Crear nuevo objeto Activo y asignar valores manualmente
                var nuevoActivo = new IntranetFM.Modelos.Activo
                {
                    _placa = form["_placa"],
                    _serie = form["_serie"],
                    _modelo = form["_modelo"],
                    _marca = new IntranetFM.Modelos.Marca { _rowid = int.Parse(form["_marca._rowid"]) },
                    _idtipoactivo = int.Parse(form["_idtipoactivo"]),
                    _ubicacion = new IntranetFM.Modelos.Ubicacion { _rowid = int.Parse(form["_ubicacion._rowid"]) },
                    _responsable = ObtenerResponsableDesdeForm(form["_responsable._rowid"]),
                    _fechacompra = DateTime.Parse(form["_fechacompra"]),
                    _estado = form["_estado"],
                    _descripcion = form["_descripcion"],
                    _observaciones = form["_observaciones"],
                    _numerodocumento = form["_numerodocumento"],
                    _garantia = int.TryParse(form["_garantia"], out int meses) ? meses : 0,
                    _fecharegistro = DateTime.Now
                };

                // Procesar imagen si se subió
                if (imagenArchivo != null && imagenArchivo.Length > 0)
                {
                    if (imagenArchivo.Length > 2 * 1024 * 1024) // 2MB
                    {
                        ModelState.AddModelError("", "La imagen no puede exceder 2MB");
                        CargarListasDesplegables();
                        return View(nuevoActivo);
                    }
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "activos");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imagenArchivo.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imagenArchivo.CopyTo(fileStream);
                    }

                    nuevoActivo._imagen = $"/uploads/activos/{uniqueFileName}";
                }
                // Procesar documento PDF (limitado a 5MB)
                if (documentoArchivo != null && documentoArchivo.Length > 0)
                {
                    if (documentoArchivo.Length > 5 * 1024 * 1024) // 5MB
                    {
                        ModelState.AddModelError("", "El documento no puede exceder 5MB");
                        CargarListasDesplegables();
                        return View(nuevoActivo);
                    }

                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "documentos");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(documentoArchivo.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        documentoArchivo.CopyTo(fileStream);
                    }

                    nuevoActivo._documento = $"/uploads/documentos/{uniqueFileName}";
                }

                // Validación manual
                if (string.IsNullOrEmpty(nuevoActivo._placa))
                    ModelState.AddModelError("_placa", "La placa es requerida");

                if (nuevoActivo._marca._rowid <= 0)
                    ModelState.AddModelError("_idmarca._rowid", "Seleccione una marca válida");


                // Guardar el activo
                IntranetFM.Class.Activos clsActivos = new IntranetFM.Class.Activos();
                bool resultado = clsActivos.Update(nuevoActivo);

                if (resultado)
                {
                    TempData["SuccessMessage"] = "Activo creado exitosamente";
                    return RedirectToAction("Listar");
                }

                ModelState.AddModelError("", "No se pudo crear el activo");
                CargarListasDesplegables();
                return View(nuevoActivo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear activo desde IFormCollection");
                ModelState.AddModelError("", $"Error al procesar el formulario: {ex.Message}");
                CargarListasDesplegables();
                return View(new IntranetFM.Modelos.Activo()); // Retorna un objeto vacío para evitar null
            }
        }

        private IntranetFM.Modelos.Persona ObtenerResponsableDesdeForm(string idResponsable)
        {
            if (string.IsNullOrWhiteSpace(idResponsable) || !int.TryParse(idResponsable, out int responsableId) || responsableId <= 0)
            {
                return new IntranetFM.Modelos.Persona
                {
                    _rowid = 0,
                    _nombre = "No asignado",
                    _identificacion = "000000000",
                    _apellido1 = "",
                    _apellido2 = "",
                    _email = "no@asignado.com"
                 
                };
            }

            // Si se seleccionó un responsable válido
            return new IntranetFM.Modelos.Persona { _rowid = responsableId };
        }
        private void CargarListasDesplegables()
        {
            try
            {
                SetContextUserMenu();
                // Marcas
                IntranetFM.Class.Marcas clsMarcas = new IntranetFM.Class.Marcas();
                ViewBag.Marcas = clsMarcas.Query(new IntranetFM.Modelos.Marca { _rowid = 0 })
                    .OrderBy(m => m._marca)
                    .Select(m => new SelectListItem
                    {
                        Text = m._marca,
                        Value = m._rowid.ToString()
                    }).ToList();

                // Ubicaciones
                IntranetFM.Class.Ubicaciones clsUbicaciones = new IntranetFM.Class.Ubicaciones();
                ViewBag.Ubicaciones = clsUbicaciones.Query(new  IntranetFM.Modelos.Ubicacion { _rowid = 0 })
                    .OrderBy(u => u._ubicacion)
                    .Select(u => new SelectListItem
                    {
                        Text = u._ubicacion,
                        Value = u._rowid.ToString()
                    }).ToList();

                // Responsables
                IntranetFM.Class.Personas clsPersonas = new IntranetFM.Class.Personas();
                ViewBag.Responsables = clsPersonas.Query(new IntranetFM.Modelos.Persona { _rowid = 0 })
                    .OrderBy(p => p._nombre)
                    .Select(p => new SelectListItem
                    {
                        Text = $"{p._nombre} {p._apellido1}",
                        Value = p._rowid.ToString()
                    }).ToList();

                // Estados
                ViewBag.Estados = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Activo" },
            new SelectListItem { Value = "2", Text = "Reparación" },
            new SelectListItem { Value = "3", Text = "Préstamos" },
            new SelectListItem { Value = "4", Text = "Desecho" }
        };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar listas desplegables");
                throw;
            }
        }
        [HttpGet]
        [Route("/Activos/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            try
            {
                IntranetFM.Class.Activos clsActivos = new IntranetFM.Class.Activos();
                var activo = clsActivos.GetById(id);

                if (activo == null)
                {
                    return NotFound();
                }
                // Cargar información relacionada
                IntranetFM.Class.Marcas clsMarcas = new IntranetFM.Class.Marcas();
                activo._marca = clsMarcas.GetById(activo._marca._rowid);

                IntranetFM.Class.Ubicaciones clsUbicaciones = new IntranetFM.Class.Ubicaciones();
                activo._ubicacion = clsUbicaciones.GetById(activo._ubicacion._rowid);

                IntranetFM.Class.Personas clsPersonas = new IntranetFM.Class.Personas();
                activo._responsable = clsPersonas.GetById(activo._responsable._rowid);

                CargarListasDesplegables();

             

                return View(activo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al cargar formulario de edición para activo {id}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("/Activos/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection form, IFormFile documentoArchivo, IFormFile imagenArchivo)
        {
            try
            {
                // 1. Obtener el activo actual
                IntranetFM.Class.Activos clsActivos = new IntranetFM.Class.Activos();
                var activoActual = clsActivos.GetById(id);
                if (activoActual == null) return NotFound();

                // 2. Crear objeto con valores actualizados
                IntranetFM.Modelos.Activo activoActualizado = new IntranetFM.Modelos.Activo
                {
                    _id = id,
                    _placa = form["_placa"],
                    _serie = form["_serie"],
                    _modelo = form["_modelo"],
                    _descripcion = form["_descripcion"],
                    _observaciones = form["_observaciones"],
                    _numerodocumento = form["_numerodocumento"],
                    _garantia = int.Parse("0"+form["_garantia"].ToString()),
                    _fecharegistro = activoActual._fecharegistro,
                    _imagen = activoActual._imagen,
                    _documento = activoActual._documento // Mantener por defecto
                };

                // 3. Asignar valores complejos con validación
                if (int.TryParse(form["_marca._rowid"], out int marcaId))
                    activoActualizado._marca = new IntranetFM.Modelos.Marca { _rowid = marcaId };

                if (int.TryParse(form["_ubicacion._rowid"], out int ubicacionId))
                    activoActualizado._ubicacion = new IntranetFM.Modelos.Ubicacion { _rowid = ubicacionId };

                if (int.TryParse(form["_responsable._rowid"], out int responsableId))
                    activoActualizado._responsable = new IntranetFM.Modelos.Persona { _rowid = responsableId };

                if (DateTime.TryParse(form["_fechacompra"], out DateTime fechaCompra))
                    activoActualizado._fechacompra = fechaCompra;

                if (int.TryParse(form["_idtipoactivo"], out int tipoActivo))
                    activoActualizado._idtipoactivo = tipoActivo;

                activoActualizado._estado = form["_estado"];

                // 4. Manejo de la imagen
                bool eliminarImagen = form["eliminarImagen"] == "true";

                string mcurrenfile = activoActualizado._imagen.ToString();
                if (eliminarImagen) { activoActualizado._imagen = "";}

                if (imagenArchivo != null && imagenArchivo.Length > 0)
                {
                    // Subir nueva imagen
                    var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "activos");
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imagenArchivo.FileName)}";
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imagenArchivo.CopyTo(stream);
                    }
                    activoActualizado._imagen = $"/uploads/activos/{uniqueFileName}";

                    eliminarImagen = (mcurrenfile != "");
                }

                //if (eliminarImagen && !string.IsNullOrEmpty(activoActual._imagen))
                if (eliminarImagen ) //Se elimina la validación de si la imagen es null ya que podría ser que la imagen no se tenga a mano y la que está en el servidor no corresponde. Jcampos 03/07/2025
                {
                    // Eliminar imagen existente
                    var imagenPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                                       mcurrenfile.TrimStart('/'));
                    if (System.IO.File.Exists(imagenPath))
                    {
                        System.IO.File.Delete(imagenPath);
                    }
                    //activoActualizado._imagen = null;
                }
                

                // 5. Manejo del documento PDF
                bool eliminarDocumento = form["eliminarDocumento"] == "true";
                mcurrenfile = activoActualizado._documento.ToString();
                if (eliminarDocumento) { activoActualizado._documento = ""; }

                if (documentoArchivo != null && documentoArchivo.Length > 0)
                {
                    // Validar tamaño del documento (5MB máximo)
                    if (documentoArchivo.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("", "El documento no puede exceder los 5MB");
                        CargarListasDesplegables();
                        return View(activoActual);
                    }

                    // Subir nuevo documento
                    var docsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "documentos");
                    var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(documentoArchivo.FileName)}";
                    var filePath = Path.Combine(docsDir, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        documentoArchivo.CopyTo(stream);
                    }
                    activoActualizado._documento = $"/uploads/documentos/{uniqueFileName}";
                }
                //if (eliminarDocumento && !string.IsNullOrEmpty(activoActual._documento))
                if (eliminarDocumento)
                {
                    // Eliminar documento existente
                    var docPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
                                     mcurrenfile.TrimStart('/'));
                    if (System.IO.File.Exists(docPath))
                    {
                        System.IO.File.Delete(docPath);
                    }
                    //activoActualizado._documento = null;
                }


                // 6. Validación manual
                var errors = new List<string>();
                if (string.IsNullOrWhiteSpace(activoActualizado._placa))
                    errors.Add("La placa es requerida");
                if (activoActualizado._marca?._rowid <= 0)
                    errors.Add("Seleccione una marca válida");
                if (activoActualizado._garantia < 0 || activoActualizado._garantia > 120)
                    errors.Add("Los meses de garantía deben estar entre 0 y 120");

                if (errors.Any())
                {
                    foreach (var error in errors) ModelState.AddModelError("", error);
                    CargarListasDesplegables();
                    return View(activoActual);
                }

                // 7. Actualizar en base de datos
                bool resultado = clsActivos.Update(activoActualizado);

                if (resultado)
                {
                    TempData["SuccessMessage"] = "Activo actualizado exitosamente";
                    return RedirectToAction("Listar");
                }

                ModelState.AddModelError("", "No se pudo actualizar el activo");
                CargarListasDesplegables();
                return View("Edit",activoActual);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar activo {id}");
                ModelState.AddModelError("", "Error al procesar la solicitud");
                IntranetFM.Class.Activos clsActivos = new IntranetFM.Class.Activos();
                CargarListasDesplegables();
                return View(clsActivos.GetById(id));
            }
        }
    

        // En ActivosController.cs
        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            try
            {
                if (SetContextUserMenu())
                {
                    IntranetFM.Class.Activos clsActivos = new IntranetFM.Class.Activos();
                    var activo = clsActivos.GetById(id);

                    if (activo == null)
                    {
                        return NotFound();
                    }

                    // Cargar información relacionada
                    IntranetFM.Class.Marcas clsMarcas = new IntranetFM.Class.Marcas();
                    activo._marca = clsMarcas.GetById(activo._marca._rowid);

                    IntranetFM.Class.Ubicaciones clsUbicaciones = new IntranetFM.Class.Ubicaciones();
                    activo._ubicacion = clsUbicaciones.GetById(activo._ubicacion._rowid);

                    IntranetFM.Class.Personas clsPersonas = new IntranetFM.Class.Personas();
                    activo._responsable = clsPersonas.GetById(activo._responsable._rowid);

                    return View(activo);
                }
                else { return RedirectToAction("Index", "Home"); }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener detalles del activo {id}");
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("ListarMovimientos/{id}")]
        public IActionResult Historial(int id)
		{
            if (SetContextUserMenu()) { 
             var filtro = new IntranetFM.Modelos.MovimientodeActivo
			{
                 _idActivo = new IntranetFM.Modelos.Activo { _id = id }
             };

			// Consultar los movimientos del activo
			var claseMovimientos = new IntranetFM.Class.MovimientosdeActivo();
			List<IntranetFM.Modelos.MovimientodeActivo> listaMovimientos = claseMovimientos.Query(filtro);
                IntranetFM.Class.Activos clsActivos = new IntranetFM.Class.Activos();
                IntranetFM.Class.Usuarios clsUsuarios = new IntranetFM.Class.Usuarios();
                var clsPersonas = new IntranetFM.Class.Personas();
                foreach (var movimiento in listaMovimientos)
                {
                    // Esto fuerza a que se ejecute el _setid y traiga los datos de la BD
                    movimiento._idActivo = clsActivos.GetById(movimiento._idActivo._id);
                    //Console.WriteLine(activo._marca._marca);
                    movimiento._idusuario = clsUsuarios.GetById(movimiento._idusuario._rowid);
                    movimiento._idusuario._persona = clsPersonas.GetById(movimiento._idusuario._persona._rowid);
                  
                }

                // Pasar el ID del activo en la ViewBag para mostrar en la vista si quieres
                ViewBag.ListaMovimientos = listaMovimientos ?? new List<IntranetFM.Modelos.MovimientodeActivo>();

            ViewBag.ActivoId = id;

			return View("ListarMovimientos", listaMovimientos);// Crear objeto base de búsqueda
            
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
		}

    }
}
public class tempValue { public string _value { get; set; } }