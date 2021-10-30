"use strict";

// Class definition
var KTCustomersList = function () {
    // Define shared variables
    var datatable;
    var filterMonth;
    var filterPayment;
    var table

    // Private functions
    var initCustomerList = function () {
        // Set date data order
        const tableRows = table.querySelectorAll('tbody tr');

        tableRows.forEach(row => {
            const dateRow = row.querySelectorAll('td');
            const realDate = moment(dateRow[5].innerHTML, "DD MMM YYYY, LT").format(); // select date from 5th column in table
            dateRow[5].setAttribute('data-order', realDate);
        });
        const rows = table.querySelectorAll('thead tr td').length;
        // Init datatable --- more info on datatables: https://datatables.net/manual/
        datatable = $(table).DataTable({
            "info": false,
            'order': [],
            'columnDefs': [
                { orderable: false, targets: 0 }, // Disable ordering on column 0 (checkbox)
                { orderable: false, targets: rows }, // Disable ordering on column 6 (actions)
            ]
        });

        // Re-init functions on every table re-draw -- more info: https://datatables.net/reference/event/draw
        datatable.on('draw', function () {
            initToggleToolbar();
            handleDeleteRows();
            toggleToolbars();
        });
    }

    // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
    var handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-customer-table-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }

    // Filter Datatable
    var handleFilterDatatable = () => {
        // Select filter options
        filterMonth = $('[data-kt-customer-table-filter="month"]');
        filterPayment = document.querySelectorAll('[data-kt-customer-table-filter="payment_type"] [name="payment_type"]');
        const filterButton = document.querySelector('[data-kt-customer-table-filter="filter"]');

        // Filter datatable on submit
        filterButton.addEventListener('click', function () {
            // Get filter values
            const monthValue = filterMonth.val();
            let paymentValue = '';

            // Get payment value
            filterPayment.forEach(r => {
                if (r.checked) {
                    paymentValue = r.value;
                }

                // Reset payment value if "All" is selected
                if (paymentValue === 'all') {
                    paymentValue = '';
                }
            });

            // Build filter string from filter options
            const filterString = monthValue + ' ' + paymentValue;

            // Filter datatable --- official docs reference: https://datatables.net/reference/api/search()
            datatable.search(filterString).draw();
        });
    }

    // Delete customer
    var handleDeleteRows = () => {
        // Select all delete buttons
        const deleteButtons = table.querySelectorAll('[data-kt-customer-table-filter="delete_row"]');

        deleteButtons.forEach(d => {
            // Delete button on click
            d.addEventListener('click', function (e) {
                e.preventDefault();
                // point to the delete button
                var _self = $(this);
                // Select parent row
                const parent = e.target.closest('tr');

                // Get customer name
                const customerName = parent.querySelectorAll('td')[1].innerText;

                // SweetAlert2 pop up --- official docs reference: https://sweetalert2.github.io/
                Swal.fire({
                    text: "هل  انت متاكد من مسح السجل؟"  ,
                    icon: "warning",
                    showCancelButton: true,
                    buttonsStyling: false,
                    confirmButtonText: "نعم, مسح!",
                    cancelButtonText: "لا, الغاء",
                    customClass: {
                        confirmButton: "btn fw-bold btn-danger",
                        cancelButton: "btn fw-bold btn-active-light-primary"
                    }
                }).then(function (result) {
                    if (result.value) {
                        var removeUrl = _self.attr('data-url');

                        fetch(removeUrl)
                            .then(function (response) { return response.json(); })
                            .then(function (result) {
                                console.log(JSON.stringify(result));
                                if (result.deleted == true) {
                                    Swal.fire({
                                        text: "لقد تم المسح!.",
                                        icon: "success",
                                        buttonsStyling: false,
                                        confirmButtonText: "حسنا!",
                                        customClass: {
                                            confirmButton: "btn fw-bold btn-primary",
                                        }
                                    }).then(function () { 
                                        // Remove current row
                                        datatable.row($(parent)).remove().draw();
                                    });
                                }
                            }, function (result) { console.error(result); })
                            .catch(function (rejected) { console.error(rejected); });
                        
                    } else if (result.dismiss === 'cancel') {
                        Swal.fire({
                            text: "تم الغاء المسح",
                            icon: "error",
                            buttonsStyling: false,
                            confirmButtonText: "حسنا!",
                            customClass: {
                                confirmButton: "btn fw-bold btn-primary",
                            }
                        });
                    }
                });
            })
        });
    }

    // Reset Filter
    var handleResetForm = () => {
        // Select reset button
        const resetButton = document.querySelector('[data-kt-customer-table-filter="reset"]');

        // Reset datatable
        resetButton.addEventListener('click', function () {
            // Reset month
            filterMonth.val(null).trigger('change');

            // Reset payment type
            filterPayment[0].checked = true;

            // Reset datatable --- official docs reference: https://datatables.net/reference/api/search()
            datatable.search('').draw();
        });
    }

    // Init toggle toolbar
    var initToggleToolbar = () => {
        // Toggle selected action toolbar
        // Select all checkboxes
        const checkboxes = table.querySelectorAll('[type="checkbox"]');

        // Select elements
        const deleteSelected = document.querySelector('[data-kt-customer-table-select="delete_selected"]');

        // Toggle delete selected toolbar
        checkboxes.forEach(c => {
            // Checkbox on click event
            c.addEventListener('click', function () {
                setTimeout(function () {
                    toggleToolbars();
                }, 50);
            });
        });

        // Deleted selected rows
        deleteSelected.addEventListener('click', function () {
            // SweetAlert2 pop up --- official docs reference: https://sweetalert2.github.io/
            Swal.fire({
                text: "هل انت متاكد من مسح الصفوف التي تم اختيارها ؟",
                icon: "warning",
                showCancelButton: true,
                buttonsStyling: false,
                confirmButtonText: "نعم, مسح!",
                cancelButtonText: "لا, الغاء",
                customClass: {
                    confirmButton: "btn fw-bold btn-danger",
                    cancelButton: "btn fw-bold btn-active-light-primary"
                }
            }).then(function (result) {

                var ids = [];
                var removeUrl = $(checkboxes[0]).attr('data-remove-url-bulk-del');
                var userParams = $(checkboxes[0]).attr('data-bulk-del-use-params');

                if (result.value) {
                    
                    // Remove all selected customers
                    checkboxes.forEach(c => {
                        if (c.checked) { 
                            var id = $(c).attr('data-id');
                            ids.push(`${id}`); 
                        }
                    });
                    debugger;
                    fetch(`${removeUrl}${(userParams == 'true' ? '?encodedIds=' :'')}${btoa(ids.join('$'))}`)
                        .then(function (response) { return response.json(); })
                        .then(function (result) {
                            debugger;;
                            if (result.deleted == true) {

                                Swal.fire({
                                    text: "تم مسح الصفوف المختاره!.",
                                    icon: "success",
                                    buttonsStyling: false,
                                    confirmButtonText: "حسنا!",
                                    customClass: {
                                        confirmButton: "btn fw-bold btn-primary",
                                    }
                                }).then(function () {
                                    // Remove all selected customers
                                    checkboxes.forEach(c => {
                                        if (c.checked) {
                                            datatable.row($(c.closest('tbody tr'))).remove().draw();
                                        }
                                    });

                                    // Remove header checked box
                                    const headerCheckbox = table.querySelectorAll('[type="checkbox"]')[0];
                                    headerCheckbox.checked = false;
                                });
                            } else {
                                Swal.fire({
                                    text: " لم تتم   عمليه المسح.",
                                    icon: "error",
                                    buttonsStyling: false,
                                    confirmButtonText: "حسنا!",
                                    customClass: {
                                        confirmButton: "btn fw-bold btn-primary",
                                    }
                                });
                            }
                        }, function (result) { console.error(result); })
                        .catch(function (rejected) { console.error(rejected); });
                   
                } else if (result.dismiss === 'cancel') {
                    Swal.fire({
                        text: "تم الغاء عمليه المسح.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "حسنا!",
                        customClass: {
                            confirmButton: "btn fw-bold btn-primary",
                        }
                    });
                }
            });
        });
    }

    // Toggle toolbars
    const toggleToolbars = () => {
        // Define variables
        const toolbarBase = document.querySelector('[data-kt-customer-table-toolbar="base"]');
        const toolbarSelected = document.querySelector('[data-kt-customer-table-toolbar="selected"]');
        const selectedCount = document.querySelector('[data-kt-customer-table-select="selected_count"]');

        // Select refreshed checkbox DOM elements 
        const allCheckboxes = table.querySelectorAll('tbody [type="checkbox"]');

        // Detect checkboxes state & count
        let checkedState = false;
        let count = 0;

        // Count checked boxes
        allCheckboxes.forEach(c => {
            if (c.checked) {
                checkedState = true;
                count++;
            }
        });

        // Toggle toolbars
        if (checkedState) {
            selectedCount.innerHTML = count;
            toolbarBase.classList.add('d-none');
            toolbarSelected.classList.remove('d-none');
        } else {
            toolbarBase.classList.remove('d-none');
            toolbarSelected.classList.add('d-none');
        }
    }

    // Public methods
    return {
        init: function () {
            table = document.querySelector('#kt_customers_table');

            if (!table) {
                return;
            }

            initCustomerList();
            initToggleToolbar();
            handleSearchDatatable(); 
            handleDeleteRows();
        }
    }
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTCustomersList.init();
});