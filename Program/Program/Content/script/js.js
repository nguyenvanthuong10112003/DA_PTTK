function view(id, className) {
    $('#' + id).attr('type', 'text')
    $('.' + className + ' .fa-solid.fa-eye-slash.d-none').removeClass('d-none')
    $('.' + className + ' .fa-solid.fa-eye').addClass('d-none')
}
function hide(id, className) {
    $('#' + id).attr('type', 'password')
    $('.' + className + ' .fa-solid.fa-eye-slash').addClass('d-none')
    $('.' + className + ' .fa-solid.fa-eye.d-none').removeClass('d-none')
}