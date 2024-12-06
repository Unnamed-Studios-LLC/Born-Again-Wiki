/*
Template Name: STUDIO ASP - Responsive Bootstrap 5 Admin Template
Version: 4.4.0
Author: Sean Ngu
Website: http://www.seantheme.com/studio-asp/
*/

var handleRenderTableData = function() {
	var table = $('#datatableDefault').DataTable({
		dom: "<'row mb-3'<'col-md-4 mb-3 mb-md-0'l><'col-md-8 text-right'<'d-flex justify-content-end'f<'ms-2'B>>>>t<'row align-items-center mt-3'<'mr-auto col-md-6'i><'mb-0 col-md-6'p>>",
		lengthMenu: [ 10, 20, 30, 40, 50 ],
		responsive: true,
		buttons: [
			{ extend: 'print', className: 'btn btn-default btn-sm' },
			{ extend: 'csv', className: 'btn btn-default btn-sm' }
		]
	});
};


/* Controller
------------------------------------------------ */
$(document).ready(function() {
	handleRenderTableData();
});