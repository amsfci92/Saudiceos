"use strict";

// Class definition
var KTModalNewCard = function () {
	var submitButton;
	var cancelButton;
	var validator;
	var form;
	var modal;
	var modalEl;

	// Init form inputs
	var initForm = function () {
		 
	}

	// Handle form validation and submittion
	var handleForm = function () {
		// Stepper custom navigation

		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		validator = FormValidation.formValidation(
			form,
			{
				fields: {
					'category_name': {
						validators: {
							notEmpty: {
								message: 'هذا الحقل مطلوب'
							}
						}
					},
					'CategoryImage': {
						validators: {
							notEmpty: {
								message: 'الصورة مطلوبه'
							}
						}
					},
					
				},

				plugins: {
					trigger: new FormValidation.plugins.Trigger(),
					bootstrap: new FormValidation.plugins.Bootstrap5({
						rowSelector: '.fv-row',
						eleInvalidClass: '',
						eleValidClass: ''
					})
				}
			}
		);

		// Action buttons
		submitButton.addEventListener('click', function (e) {
			// Prevent default button action
			e.preventDefault();

			// Validate form before submit
			if (validator) {
				validator.validate().then(function (status) {
					console.log('validated!');

					if (status == 'Valid') {
						// Show loading indication
						submitButton.setAttribute('data-kt-indicator', 'on');

						// Disable button to avoid multiple click 
						submitButton.disabled = true;

						var categoryImage = $('#CategoryImage').val();
						var categoryName = $('#category_name').val();

						var formData = {
							Name: categoryName,
							ImageUrl: categoryImage
						};
						 debugger
						$.ajax({
							url: `/admin/service/addcategory`,
							type: "POST",
							data: formData, 
							success: function (result) {
								// Remove loading indication
								submitButton.removeAttribute('data-kt-indicator');

								// Enable button
								submitButton.disabled = false;

								// Show popup confirmation 
								Swal.fire({
									text: "تم الحفظ بنجاح",
									icon: "success",
									buttonsStyling: false,
									confirmButtonText: "حسنا",
									customClass: {
										confirmButton: "btn btn-primary"
									}
								}).then(function (result) {
									if (result.isConfirmed) {
										modal.hide();
										loadCats();
									}
								});
							},
							error: function (xhr) {
								Swal.fire({
									text: "لم يتم الحفظ",
									icon: "error",
									buttonsStyling: false,
									confirmButtonText: "حسنا!",
									customClass: {
										confirmButton: "btn btn-primary"
									}
								});
							}
						}); 
					} else {
						// Show popup warning. For more info check the plugin's official documentation: https://sweetalert2.github.io/
						Swal.fire({
							text: "لابد من اكمال كافه البيانات المطلوبه",
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "حسنا!",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						});
					}
				});
			}
		});

	}

	return {
		// Public functions
		init: function () {
			// Elements
			modalEl = document.querySelector('#kt_modal_new_card');

			if (!modalEl) {
				return;
			}

			modal = new bootstrap.Modal(modalEl);

			form = document.querySelector('#kt_modal_new_card_form');
			submitButton = document.getElementById('kt_modal_new_card_submit'); 
			initForm();
			handleForm();
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTModalNewCard.init();
});