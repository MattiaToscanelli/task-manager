function closeModal() {
    var myModalEl = document.getElementById('addBoardModal');
    var modal = bootstrap.Modal.getInstance(myModalEl) || new bootstrap.Modal(myModalEl);
    modal.hide();
}