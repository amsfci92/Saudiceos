"use strict";

// Class definition
var KTSigninGeneral = function () {
    // Elements
    var form;
    var submitButton;
    var validator;

    // Handle form
    var handleForm = function (e) {
        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validator = FormValidation.formValidation(
            form,
            {
                fields: {
                    'UserName': {
                        validators: {
                            notEmpty: {
                                message: 'البريد الالكتروني مطلوب'
                            }
                        }
                    },
                    'Password': {
                        validators: {
                            notEmpty: {
                                message: 'كلمة المرور مطلوبه'
                            }
                        }
                    }
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row'
                    })
                }
            }
        );

        // Handle form submit
        submitButton.addEventListener('click', function (e) {
            // Prevent button default action
            
            e.preventDefault();

            // Validate form
            validator.validate().then(function (status) {
                if (status == 'Valid') {
                    // Show loading indication
                    submitButton.setAttribute('data-kt-indicator', 'on');

                    //// Disable button to avoid multiple click 
                    //submitButton.disabled = true;
                    //form.querySelector('[name="UserName"]').value = "";
                    //form.querySelector('[name="Password"]').value= "";
                   
                    // Enable button
                    //submitButton.disabled = false;
                    // Simulate ajax request
                    //setTimeout(function() {
                    //    // Hide loading indication
                    //submitButton.removeAttribute('data-kt-indicator');

                    //    // Enable button
                    //submitButton.disabled = false;

                    //    // Show message popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                    //Swal.message({
                    //        text: "جاري تسجيل الدخول!",
                    //        icon: "success",
                    //        buttonsStyling: false,
                    //        confirmButtonText: "Ok, got it!",
                    //        customClass: {
                    //            confirmButton: "btn btn-primary"
                    //        }
                    //    }).then(function (result) {
                    //        if (result.isConfirmed) {        
                    //            form.submit(); // submit form
                    //        }
                    //    });

                    let timerInterval
                    Swal.fire({
                        title: 'جاري تسجيل الدخول!',
                        html: ' <b></b>.',
                        timer: 1000,
                        timerProgressBar: true,
                        didOpen: () => {
                            Swal.showLoading()
                            const b = Swal.getHtmlContainer().querySelector('b')
                            timerInterval = setInterval(() => {
                                b.textContent = Swal.getTimerLeft()
                            }, 100)
                        },
                        willClose: () => {
                            clearInterval(timerInterval)
                        }
                    }).then((result) => {
                        /* Read more about handling dismissals below */
                        if (result.dismiss === Swal.DismissReason.timer) {
                            form.submit();
                        }
                    })
                    //}, 2000);  
                } else {
                    // Show error popup. For more info check the plugin's official documentation: https://sweetalert2.github.io/
                    Swal.fire({
                        text: "عفوا, بيانات غيسر صحيحه.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "حسنا!",
                        customClass: {
                            confirmButton: "btn btn-primary"
                        }
                    });
                    return false;
                }
            });
        });
    }

    // Public functions
    return {
        // Initialization
        init: function () {
            form = document.querySelector('#kt_sign_in_form');
            submitButton = document.querySelector('#kt_sign_in_submit');

            handleForm();
        }
    };
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTSigninGeneral.init();
});
