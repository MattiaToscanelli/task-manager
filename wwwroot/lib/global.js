function closeModal(name) {
    var myModalEl = document.getElementById(name);
    var modal = bootstrap.Modal.getInstance(myModalEl) || new bootstrap.Modal(myModalEl);
    modal.hide();
}

function closeOffcanvas() {
    var offcanvasEl = document.getElementById('offcanvasWithBackdrop');
    if (offcanvasEl) {
        var offcanvas = bootstrap.Offcanvas.getInstance(offcanvasEl);
        if (offcanvas) {
            offcanvas.hide();
        }
    }
}

function showEditTaskModal() {
    const modalEl = document.getElementById('editTaskModal');
    if (modalEl) {
        const modal = new bootstrap.Modal(modalEl);
        modal.show();
    }
}