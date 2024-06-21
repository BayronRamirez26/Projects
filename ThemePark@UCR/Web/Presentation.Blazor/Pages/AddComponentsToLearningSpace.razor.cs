using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities;
using System.Text.Json;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.LearningSpace.Entities.Wrappers;
using UCR.ECCI.PI.ThemePark_UCR.DomainWeb.Shared.ValueObjects;
using System.Numerics;
using System.ComponentModel.DataAnnotations;
using BlazorStrap.V5;
using System.Drawing;
using System;

namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Blazor.Pages
{
    public partial class AddComponentsToLearningSpace
    {
        private Component newComponent { get; set; } = new Component();
        private Templates? template;
        private bool _isDisabled = true;
        private bool isOutside = false;

        private bool colitionFlag = false;

        private void CloseMe(bool success)
        {
            Console.WriteLine("Closing alert");
            Console.WriteLine(success);
            if (success)
            {
                colitionFlag = false;
            }
            // StateHasChanged();
        }

        private bool IsDisabled
        {
            get => _isDisabled;
            set
            {
                if (_isDisabled != value)
                {
                    _isDisabled = value;
                    StateHasChanged();
                }
            }
        }
        public double sizeXUnity;
        public double sizeYUnity;

        private string userColor = "#0000FF";
        private string rectangleColor = "#0000FF";
        private BSModal? modal;

        private string? ModalTitle;
        private string? ModalContent;
        private string? ColorStatus;

        private async Task HandleValidSubmit()
        {
            if (template == null)
            {
                ModalTitle = "No se pudo agregar componentes";
                ModalContent = "No se pudo agregar componentes porque no se ha seleccionado un template.";
                ColorStatus = "#B14212";
                await modal?.ShowAsync();
                return;
            }

            Template_Has_Components template_Has_Components = new Template_Has_Components(
                GuidWrapper.Create(Guid.NewGuid()),
                MediumName.Create(newComponent.Type),
                GuidWrapper.Create(template.Id),
                DoubleWrapper.Create(sizeXUnity),
                DoubleWrapper.Create(sizeYUnity),
                DoubleWrapper.Create(newComponent.PositionX),
                DoubleWrapper.Create(newComponent.PositionY),
                DoubleWrapper.Create(newComponent.PositionZ),
                DoubleWrapper.Create(newComponent.Rotation),
                DoubleWrapper.Create(0.0)
            );

            await TemplateService.AddComponentToTemplateAsync(template_Has_Components);

            ModalTitle = "Componente agregado exitosamente!";
            ModalContent = "¿Desea agregar otro componente?";
            ColorStatus = "#95B60A";
            await modal?.ShowAsync();
        }

        private void HandleCancel()
        {
            NavigationManager.NavigateTo("/list-templates");
        }

        private void CloseModal()
        {
            modal?.HideAsync();
            NavigationManager.NavigateTo("/list-templates");
        }

        private void ConfirmSubmit()
        {
            modal?.HideAsync();
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }

        private void OnTypeChanged(string type)
        {
            newComponent.Type = type;
            _ = ValidateFormAsync();
        }

        private async Task OnPositionXChanged(double positionX)
        {
            newComponent.PositionX = positionX;
            await ValidateFormAsync();
        }

        private async Task OnPositionYChanged(double positionY)
        {
            newComponent.PositionY = positionY;
            await ValidateFormAsync();
        }

        private async Task OnPositionZChanged(double positionZ)
        {
            newComponent.PositionZ = positionZ;
            await ValidateFormAsync();
        }

        private async Task OnSizeXChanged(double sizeX)
        {
            newComponent.SizeX = sizeX;
            await ValidateFormAsync();
        }

        private async Task OnSizeYChanged(double sizeY)
        {
            newComponent.SizeY = sizeY;
            await ValidateFormAsync();
        }

        private async void OnRotationChanged(double rotation)
        {
            newComponent.Rotation = rotation;
            await ValidateFormAsync();
        }

        private async Task<bool> IsFormValidAsync()
        {
            var validationContext = new ValidationContext(newComponent);
            var validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(newComponent, validationContext, validationResults, true) && AreValuesValid();
            if (valid)
            {
                translateValues();

                var test = await checkCollision(newComponent);
                isOutside = OutsideValidation();
                StateHasChanged();

                if (test)
                {
                    colitionFlag = true;
                    StateHasChanged();
                    Console.WriteLine("HAY COLISIONES");

                }
                else
                {
                    colitionFlag = false;
                    StateHasChanged();
                    Console.WriteLine("NO HAY COLISIONES");
                }
                if (!test && !isOutside)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return valid;
        }

        private bool translateValues()
        {
            if (newComponent.Type == "Pizarra")
            {
                sizeXUnity = newComponent.SizeX * 0.09; // Translate from meters to unity values
                Console.WriteLine("SE TRADUCE A UNITY");
                Console.WriteLine(newComponent.SizeX);
                sizeYUnity = newComponent.SizeY * 0.08;
            }
            else if (newComponent.Type == "Pantalla Interactiva")
            {
                sizeXUnity = newComponent.SizeX * 1.6;
                sizeYUnity = newComponent.SizeY * 1.6;
            }
            else if (newComponent.Type == "Proyector")
            {
                sizeXUnity = newComponent.SizeX * 0.8;
                sizeYUnity = newComponent.SizeY * 0.72;
            }
            return false;
        }
        private bool AreValuesValid()
        {
            return newComponent.SizeX > 0
                   && newComponent.SizeY > 0;
        }

        private async Task ValidateFormAsync()
        {
            IsDisabled = !await IsFormValidAsync();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var uri = new Uri(NavigationManager.Uri);
            var templateJson = uri.Query.Replace("?template=", "");
            var decodedTemplateJson = Uri.UnescapeDataString(templateJson);
            template = JsonSerializer.Deserialize<Templates>(decodedTemplateJson);
            _ = ValidateFormAsync();
        }

        public class Component : IValidatableObject
        {
            [Required(ErrorMessage = "El ancho del componente debe ser brindado")]
            [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor que cero.")]
            public double SizeX { get; set; }

            [Required(ErrorMessage = "El alto del componente debe ser brindado")]
            [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor que cero.")]
            public double SizeY { get; set; }

            [Required(ErrorMessage = "La posición X del componente debe ser brindada")]
            public double PositionX { get; set; }

            [Required(ErrorMessage = "La posición Y del componente debe ser brindada")]
            public double PositionY { get; set; }

            [Required(ErrorMessage = "La posición Z del componente debe ser brindada")]
            public double PositionZ { get; set; }

            [Required(ErrorMessage = "El tipo debe ser brindado")]
            public string? Type { get; set; }

            [Required(ErrorMessage = "La rotación del componente debe ser brindada")]
            [Range(-360, 360, ErrorMessage = "El valor debe ser mayor que -360 y menor que 360.")]
            public double Rotation { get; set; }


            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                var results = new List<ValidationResult>();

                if (SizeX <= 0)
                {
                    results.Add(new ValidationResult("El ancho del componente debe ser mayor que cero.", new[] { nameof(SizeX) }));
                }

                if (SizeY <= 0)
                {
                    results.Add(new ValidationResult("El alto del componente debe ser mayor que cero.", new[] { nameof(SizeY) }));
                }

                return results;
            }
        }

        public class OBB
        {
            public Vector3 Center { get; }
            public Vector3 Size { get; }
            public Vector3 Rotation { get; } // Rotation in degrees (around X, Y, Z axes)

            public OBB(Vector3 center, Vector3 size, Vector3 rotation)
            {
                Center = center;
                Size = size;
                Rotation = rotation;
            }

            private Vector3 GetHalfSize()
            {
                return new Vector3(Size.X / 2, Size.Y / 2, Size.Z / 2);
            }

            private Matrix4x4 GetRotationMatrix()
            {
                // Convert Rotation to radians
                var rotationX = Matrix4x4.CreateRotationX(MathF.PI * (float)Rotation.X / 180.0f);
                var rotationY = Matrix4x4.CreateRotationY(MathF.PI * (float)Rotation.Y / 180.0f);
                var rotationZ = Matrix4x4.CreateRotationZ(MathF.PI * (float)Rotation.Z / 180.0f);
                return rotationX * rotationY * rotationZ;
            }

            public bool IsCollidingWith(OBB other)
            {
                Vector3[] axes = GetAxes().Concat(other.GetAxes()).ToArray();
                foreach (var axis in axes)
                {
                    if (!IsOverlappingOnAxis(this, other, axis))
                    {
                        return false;
                    }
                }
                return true;
            }

            private Vector3[] GetAxes()
            {
                var rotationMatrix = GetRotationMatrix();
                var halfSize = GetHalfSize();
                return new Vector3[]
                {
                Vector3.Normalize(Vector3.TransformNormal(new Vector3(1, 0, 0), rotationMatrix)),
                Vector3.Normalize(Vector3.TransformNormal(new Vector3(0, 1, 0), rotationMatrix)),
                Vector3.Normalize(Vector3.TransformNormal(new Vector3(0, 0, 1), rotationMatrix))
                };
            }

            private static bool IsOverlappingOnAxis(OBB a, OBB b, Vector3 axis)
            {
                var aProjection = ProjectOntoAxis(a, axis);
                var bProjection = ProjectOntoAxis(b, axis);
                return aProjection.min <= bProjection.max && bProjection.min <= aProjection.max;
            }

            private static (double min, double max) ProjectOntoAxis(OBB obb, Vector3 axis)
            {
                Vector3[] corners = GetCorners(obb);
                double min = Vector3.Dot(axis, corners[0]);
                double max = min;
                for (int i = 1; i < corners.Length; i++)
                {
                    double projection = Vector3.Dot(axis, corners[i]);
                    if (projection < min) min = projection;
                    if (projection > max) max = projection;
                }
                return (min, max);
            }

            private static Vector3[] GetCorners(OBB obb)
            {
                var rotationMatrix = obb.GetRotationMatrix();
                var halfSize = obb.GetHalfSize();
                return new Vector3[]
                {
                obb.Center + Vector3.TransformNormal(new Vector3( halfSize.X,  halfSize.Y,  halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3(-halfSize.X,  halfSize.Y,  halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3( halfSize.X, -halfSize.Y,  halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3(-halfSize.X, -halfSize.Y,  halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3( halfSize.X,  halfSize.Y, -halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3(-halfSize.X,  halfSize.Y, -halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3( halfSize.X, -halfSize.Y, -halfSize.Z), rotationMatrix),
                obb.Center + Vector3.TransformNormal(new Vector3(-halfSize.X, -halfSize.Y, -halfSize.Z), rotationMatrix)
                };
            }
        }


        public class Room
        {
            public Vector3 Size { get; }

            public Room(Vector3 size)
            {
                Size = size;
            }

            public OBB[] GetRoomOBBs()
            {
                // must use half size because center of the room is the geometric center
                Vector3 halfSize = Size / 2;

                // floor OBB
                OBB floor = new OBB(
                    new Vector3(0, 0, 0),
                    new Vector3(Size.X, 0, Size.Z),
                    new Vector3(0, 0, 0));

                // ceiling OBB
                OBB ceiling = new OBB(
                    new Vector3(0, Size.Y, 0),
                    new Vector3(Size.X, 0, Size.Z),
                    new Vector3(0, 0, 0));

                // front wall OBB
                OBB frontWall = new OBB(
                    new Vector3(0, halfSize.Y, -halfSize.Z),
                    new Vector3(Size.X, Size.Y, 0),
                    new Vector3(0, 0, 0));

                // back wall OBB
                OBB backWall = new OBB(
                    new Vector3(0, halfSize.Y, halfSize.Z),
                    new Vector3(Size.X, Size.Y, 0),
                    new Vector3(0, 0, 0));

                // left wall OBB
                OBB leftWall = new OBB(
                    new Vector3(-halfSize.X, halfSize.Y, 0),
                    new Vector3(0, Size.Y, Size.Z),
                    new Vector3(0, 0, 0));

                // right wall OBB
                OBB rightWall = new OBB(
                    new Vector3(halfSize.X, halfSize.Y, 0),
                    new Vector3(0, Size.Y, Size.Z),
                    new Vector3(0, 0, 0));

                return new OBB[] { floor, ceiling, frontWall, backWall, leftWall, rightWall };


            }
        }

        private bool OutsideValidation()
        {
            // check if the new component is outside the room

            // Geometric center projected on the lower side
            double centerX = template.SizeX.Value / 2.0;
            double centerY = 0;  // Lower side
            double centerZ = template.SizeZ.Value / 2.0;

            // Adjust point coordinates relative to the geometric center
            double adjustedX = newComponent.PositionX + centerX;
            double adjustedY = newComponent.PositionY + centerY;
            double adjustedZ = newComponent.PositionZ + centerZ;

            // Check if the adjusted point is inside the environment dimensions
            if (adjustedX < 0 || adjustedX > template.SizeX.Value ||
                adjustedY < 0 || adjustedY > template.SizeY.Value ||
                adjustedZ < 0 || adjustedZ > template.SizeZ.Value)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Check if the new component is colliding with any other component in the template
        /// </summary>
        /// <param name="newComponent"></param>
        /// <returns></returns>
        private async Task<bool> checkCollision(Component newComponent)
        {
            // check if template is null
            if (template == null)
            {
                return true;
            }

            // check if new component is null
            if (newComponent == null)
            {
                return true;
            }

            // in the current implementation each sizeZ are constant values for each type of component
            // so based on the type of the new component, we can get the sizeZ value
            float sizeZ = 1.0f;

            // get the offset needed to get the geometric center (fix for the assets who are not correctly centered)
            float offsetX = 0.0f;
            float offsetY = 0.0f;
            float offsetZ = 0.0f;

            if (newComponent.Type == "Pizarra")
            {
                offsetX = 0.0f;
                offsetY = 0.0f;
                offsetZ = -0.3f;
            }
            else if (newComponent.Type == "Proyector")
            {
                offsetX = 0.0f;
                offsetY = (float)newComponent.SizeY / 2;
                offsetZ = sizeZ;
            }
            else if (newComponent.Type == "Punto de Accesso")
            {
                offsetX = 0.0f;
                offsetY = 0.0f;
                offsetZ = 0.0f;
            }
            else if (newComponent.Type == "Pantalla Interactiva")
            {
                offsetX = 0.0f;
                offsetY = (float)newComponent.SizeY / 2;
                offsetZ = 0.0f;
            }

            // get the position of the new component
            Vector3 position = new Vector3(
                (float)newComponent.PositionX + offsetX,
                (float)newComponent.PositionY + offsetY,
                (float)newComponent.PositionZ + offsetZ);

            // get the size of the new component
            Vector3 size = new Vector3(
                // Meters                 
                (float)newComponent.SizeX,
                (float)newComponent.SizeY,
                (float)sizeZ);

            Console.WriteLine("sizeX of newComponent: " + newComponent.SizeX);
            Console.WriteLine("sizeY of newComponent: " + newComponent.SizeY);

            // get the rotation of the new component
            Vector3 rotation = new Vector3(0, (float)newComponent.Rotation, 0); // change rotation on Z axis to actual value

            // create a new AABB object for the new component
            // AABB newAABB = new AABB(position, size, rotation);
            OBB newOBB = new OBB(position, size, rotation);


            // create an OBB for each walls, ceiling, and floor
            Vector3 roomSize = new Vector3((float)template.SizeX.Value, (float)template.SizeY.Value, (float)template.SizeZ.Value);
            Room room = new Room(roomSize);

            // loop through all the OBBs in the room
            foreach (OBB roomOBB in room.GetRoomOBBs())
            {
                // check if the new component is colliding with any of the room OBBs
                if (newOBB.IsCollidingWith(roomOBB))
                {
                    return true;
                }
            }

            // get all the components in the template
            IEnumerable<Template_Has_Components> template_Has_Components = await TemplateService.GetComponents_From_TemplateAsync(GuidWrapper.Create(template.Id));

            // loop through all the components in the template
            foreach (Template_Has_Components component in template_Has_Components)
            {
                var componentType = component.Component_type.Value;

                float sizeXObject = 0.0f;
                float sizeYObject = 0.0f;
                float sizeZObject = 0.0f;

                if (newComponent.Type == "Pizarra")
                {
                    // hardcoded values for size of the whiteboard in unity, if changed in unity, need to change here
                    sizeXObject = 7.430774f;
                    sizeYObject = 2.451409f;
                    sizeZObject = 0.3611204f;

                    offsetX = 0.0f;
                    offsetY = (float)(component.SizeY.Value * sizeYObject) / 2;
                    offsetZ = 0.0f;
                }
                else if (newComponent.Type == "Proyector")
                {
                    // hardcoded values for size of the whiteboard in unity, if changed in unity, need to change here
                    sizeXObject = 1.168802f;
                    sizeYObject = 1.34687f;
                    sizeZObject = 3.152125f;

                    offsetX = 0.0f;
                    offsetY = (float)(component.SizeY.Value * sizeYObject) / 2;
                    offsetZ = sizeZ;
                }
                else if (newComponent.Type == "Punto de Accesso")
                {
                    // hardcoded values for size of the whiteboard in unity, if changed in unity, need to change here
                    sizeXObject = 0.2457406f;
                    sizeYObject = 2.372688f;
                    sizeZObject = 1f;

                    offsetX = 0.0f;
                    offsetY = 0.0f;
                    offsetZ = 0.0f;
                }
                else if (newComponent.Type == "Pantalla Interactiva")
                {
                    // hardcoded values for size of the whiteboard in unity, if changed in unity, need to change here
                    sizeXObject = 0.6252108f;
                    sizeYObject = 0.6302114f;
                    sizeZObject = 0.1318579f;

                    offsetX = 0.0f;
                    offsetY = (float)(component.SizeY.Value * sizeYObject) / 2;
                    offsetZ = 0.0f;
                }


                // get the position of the existing component
                Vector3 existingPosition = new Vector3(
                    (float)component.PositionX.Value + offsetX,
                    (float)component.PositionY.Value + offsetY,
                    (float)component.PositionZ.Value + offsetZ);

                // get the size of the existing component
                // need to cast current value to be actual meters
                Vector3 existingSize = new Vector3(
                    (float)component.SizeX.Value * sizeXObject,
                (float)component.SizeY.Value * sizeYObject,
                (float)sizeZ * sizeZObject);

                Console.WriteLine("sizeX of existingComponent: " + component.SizeX.Value);
                Console.WriteLine("sizeY of existingComponent: " + component.SizeY.Value);



                // get the rotation of the existing component
                Vector3 existingRotation = new Vector3(0, (float)component.RotationX.Value, 0); // change rotation on Z axis to actual value

                // create a new OBB object for the existing component
                OBB existingOBB = new OBB(existingPosition, existingSize, existingRotation);

                // check if the new component is colliding with any of the existing components
                if (newOBB.IsCollidingWith(existingOBB))
                {
                    return true;
                }
            }
            // loop through all the components in the scene
            // check if the new component is colliding with any of the existing components
            // if there is a collision, return true
            // if there is no collision, return false

            // if no check returned true, then is is not colliding with any other component
            return false;
        }
    }
}