function closeModal(name) {
    var myModalEl = document.getElementById(name);
    var modal = bootstrap.Modal.getInstance(myModalEl) || new bootstrap.Modal(myModalEl);
    modal.hide();
}

function collapseNavbar() {
    var navbar = document.getElementById('navbarNav');
    if (navbar.classList.contains('show')) {
        new bootstrap.Collapse(navbar).hide();
    }
}