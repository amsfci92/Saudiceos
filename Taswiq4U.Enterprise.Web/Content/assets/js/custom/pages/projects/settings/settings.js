"use strict";

// Class definition
var KTProjectSettings = function () {

    // Private functions
    var handleForm = function () {
        // Init Datepicker --- For more info, please check Flatpickr's official documentation: https://flatpickr.js.org/
        $("#kt_datepicker_1").flatpickr();
        $("#kt_datepicker_11").flatpickr();

        // Form validation
        var validation;
        var _form = document.getElementById('kt_project_settings_form');

        // Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
        validation = FormValidation.formValidation(
            _form,
            {
                fields: {
                    name: {
                        validators: {
                            notEmpty: {
                                message: 'Project name is required'
                            }
                        }
                    },
                    type: {
                        validators: {
                            notEmpty: {
                                message: 'Project type is required'
                            }
                        }
                    },
                    description: {
                        validators: {
                            notEmpty: {
                                message: 'Project Description is required'
                            }
                        }
                    },
                    date: {
                        validators: {
                            notEmpty: {
                                message: 'Due Date is required'
                            }
                        }
                    },
                },
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    //defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                    bootstrap: new FormValidation.plugins.Bootstrap5({
                        rowSelector: '.fv-row'
                    })
                }
            }
        );
    }

    // Public methods
    return {
        init: function () {
            handleForm();
        }
    }
}();


// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTProjectSettings.init();
});
