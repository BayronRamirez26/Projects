var varbaseUrl = '@Url.Content("~/")'
function GenerarMenu(param) {
    var str = "";
    if (param != null) {
        str += "<ul class='navbar-nav flex-grow-1'>";
        param.forEach(function (menuitem) {
            if (menuitem._Items == null) {
                menuitem._Items = "";
            }
            if (menuitem._Items != "") {
                str += "<li class='nav-item dropdown'>";
                str += "<a class='nav-link dropdown-toggle' style='color:white' href='#' data-bs-toggle='dropdown' aria-expanded='false' tabindex='0'>";
                str += menuitem._Nombre;
                str += "</a>";

                var submenu = menuitem._Items;
                str += "<ul class='dropdown-menu dropdown-menu-dark' style='background-color:#DDF3F4; border: 2px solid #0BBBEC;'>";
                submenu.forEach(function (subitem) {
                    str += "<li><a class='dropdown-item' style='color:black' href='/" + subitem._url + "'>" + subitem._Nombre + "</a></li>";
                });
                str += "</ul>";
                str += "<li>";
            } else {

                str += "<div class='d-flex ms-auto'>";
                str += "<a class='nav-link text-white' href='/" + menuitem._url + "'>" + menuitem._Nombre + "</a>";
                str += "</div>";
            }

        });
        str += "</ul>";
    }

    return str;
}