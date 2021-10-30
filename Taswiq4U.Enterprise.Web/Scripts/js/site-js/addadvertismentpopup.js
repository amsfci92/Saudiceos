function a_a_p(country, language, nextText, prevText, makesurecompletedText, wrefreshpage, pleaseaddphotoText, baseUrl, userPhone) {
    var advertismentDetails = {}
    function setCatName() {
        $('.cat_name').html(window.CatName != null ? window.CatName:"")
    }
    // get sat sp
    function getCAtegorySpecifications(categoryId) {
        spinner.show();
        setCatName();
        $('#smartwizard').smartWizard("loader", "show");
        var wizard = $('#smartwizard');
        setTimeout(function () {

            $('.tab-content').css({ height: 'auto' });
            $('.category-specification-details').load(`/CategorySpecificationDetails/${categoryId}`, function (responseTxt, statusTxt, jqXHR) {
                if (statusTxt == "success") {
                    //alert("New content loaded successfully!");
                    if (responseTxt == '') {
                        $('.sw-btn-next').click();

                    } 
                    wizard.smartWizard("loader", "hide");
                }
                if (statusTxt == "error") {
                    show("Error: " + jqXHR.status + " " + jqXHR.statusText);
                }
            });
            spinner.hide();

        }, 1150);

    }
    // Ajax content loading with "stepContent" event
    function getSubCats(index, className, foundCats, horzM) {
        spinner.show();

        $.get(`/Api/Category/GetSubCategoriesList/${index}`, function (data) {
            if (data != null) {
                console.log(data);
                if (data.length > 0) {
                    var html = _.map(data, function (obj) {
                        return `<a href="#" data-catName="${language == 'ar' ? obj.ArabicDescription : obj.EnglishDescription}" class="list-group-item list-group-item-action ${className} ${obj.HasHorizontalMenu == true ?"HasHorizontalMenu":""}" data-index="${obj.Id}">
                                <span>${language == 'ar' ? obj.ArabicDescription : obj.EnglishDescription}</span>
                                 <span>${obj.CategoryLogo != null ? `<img width='30' height='30' src='${baseUrl}/Api/ImageUpload/i?url=${obj.CategoryLogo}&type=3'/>` : ''}</span></a>`
                    })
                    if (foundCats != undefined)
                        foundCats(html)
                } else {
                    advertismentDetails.CategoryId = index;
                    getCAtegorySpecifications(index);
                    $('.sw-btn-next').click();
                }

            } else {

            }
            spinner.hide();

        })

    }
    // get categories
    function addSubMenuEventAction() {
        $('.sub-category-list-item').click(function () {
            var index = this.dataset['index'];
            window.CatName = $(this).attr('data-catName');

            getSubCats(index, 'third-sub-category-list-item', function (html) {
                $('.third-sub-category-list').html(html);
                $('.third-sub-category-list').show();
                // clear
                $('.forth-sub-category-list').html('');
                $('.fifth-sub-category-list').html('');
                $('.sixth-sub-category-list').html('');
                addThirdSubCat();
            })
        });
    }
    function addThirdSubCat() {
        $('.third-sub-category-list-item').click(function () {
            advertismentDetails.CategoryId = this.dataset.index;
            window.CatName = $(this).attr('data-catName');

            var index = this.dataset['index'];
            getSubCats(index, 'forth-sub-category-list-item', function (html) {
                $('.forth-sub-category-list').html(html);
                $('.forth-sub-category-list').show();
                // clear
                $('.fifth-sub-category-list').html('');
                $('.sixth-sub-category-list').html('');

                addforthSubCat();
            })
        })
    }
    function addforthSubCat() {
        $('.forth-sub-category-list-item').click(function () {
            advertismentDetails.CategoryId = this.dataset.index;
            window.CatName = $(this).attr('data-catName');

            var index = this.dataset['index'];

            getSubCats(index, 'fifth-sub-category-list-item', function (html) {
                $('.fifth-sub-category-list').html(html);
                $('.fifth-sub-category-list').show();
                $('.sixth-sub-category-list').html('');

                addfifthSubCat();
            })
        })
    }
    function addfifthSubCat() {
        $('.fifth-sub-category-list-item').click(function () {
            advertismentDetails.CategoryId = this.dataset.index;
            window.CatName = $(this).attr('data-catName');

            var index = this.dataset['index'];

            getSubCats(index, 'sixth-sub-category-list-item', function (html) {
                $('.sixth-sub-category-list').html(html);
                $('.sixth-sub-category-list').show();
                addsixthSubCat();
            }, $(this).hasClass('HasHorizontalMenu'))

        })
    }
    function addsixthSubCat() {
        $('.sixth-sub-category-list-item').click(function () {
            advertismentDetails.CategoryId = this.dataset.index;
            window.CatName = $(this).attr('data-catName');
            var index = this.dataset['index'];

            getSubCats(index, '', function (html) {
                $('.third-sub-category-list').html(html);
                $('.third-sub-category-list').show();
                // addfifthSubCat();
            }, $(this).hasClass('HasHorizontalMenu'))

        })
    }
    function ValidateSP() {
        var inputs = $('.category-specification-details').find('input');
        var adDetailsInput = $('.advertisment-details').find('input');
        var adDetailsTE = $('.advertisment-details').find('textarea');
        var selects = $('.category-specification-details').find('select');
        var tereas = $('.category-specification-details').find('textarea');
        var errors = true;
        if (selects.length > 0) {
            for (var i = 0; i < selects.length; i++) {
                if (selects[i].required && selects[i].value == 0) {
                    errors = false;
                    $(selects[i]).parent().children('')[0].style.color = 'red'
                } else {
                    $(selects[i]).parent().children('')[0].style.color = 'black'
                }
            }
        }
        if (inputs.length > 0) {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].required && inputs[i].value == 0) {
                    errors = false;
                    $(inputs[i]).parent().children('')[0].style.color = 'red'
                } else {
                    $(inputs[i]).parent().children('')[0].style.color = 'black'
                }
            }
        }
        if (adDetailsInput.length > 0) {
            for (var i = 0; i < adDetailsInput.length; i++) {
                if (adDetailsInput[i].required && adDetailsInput[i].value == 0) {
                    errors = false;
                    $(adDetailsInput[i]).parent().children('')[0].style.color = 'red'
                }
                else if (adDetailsInput[i].min == 0 && parseInt(adDetailsInput[i].value) < 0) {
                    errors = false;
                    $(adDetailsInput[i]).parent().children('')[0].style.color = 'red'
                } else {
                    $(adDetailsInput[i]).parent().children('')[0].style.color = 'black'
                }
                
            }
        }

        if (adDetailsTE.length > 0) {
            for (var i = 0; i < adDetailsTE.length; i++) {
                if (adDetailsTE[i].required && adDetailsTE[i].value == 0) {
                    errors = false;
                    $(adDetailsTE[i]).parent().children('')[0].style.color = 'red'
                } else {
                    $(adDetailsTE[i]).parent().children('')[0].style.color = 'black'
                }
            }
        }
        var dfieldsList = [];
        _.map(selects, function (s) {

            if ($(s).select2('val').length > 0) {

                dfieldsList.push({ Id: s.dataset.index, CustomValue: '', AdvertismentSpecificatioOptions: Array.isArray($(s).select2('val')) ? $(s).select2('val') : [$(s).select2('val')] })
            } 

        })
        _.map(inputs, function (s) {
            if (s.value != '') {
             
                dfieldsList.push({ Id: s.dataset.index, CustomValue: s.value, AdvertismentSpecificatioOptions:null })
            }
        })
        console.log(dfieldsList)
        return {
            errors, dfieldsList
        }
    }
    function setCitySelectList() {
        $(".city-list-item").click(function () {

            var CityId = parseInt(this.dataset.index);

            if (CityId > 0) {
                advertismentDetails.CityId = CityId;
                $.ajax({
                    type: "get",
                    url: `/Api/CountryApi/GetActiveCitiesStates/${CityId}`,
                    data: { cityId: CityId },
                    success: function (data) {
                        if (data.status == true) {
                            if (data.citiesMapped.length > 0) {
                                var html = _.map(data.citiesMapped, function (obj) {
                                    return `<a href="#" class="list-group-item list-group-item-action sub-state-list-item" data-index="${obj.Id}">${language == 'ar' ? obj.NameAr : obj.NameEn}</a>`
                                })
                                $(".state-list").html(html);
                                $(".state-list").show();
                                addStateEventAction();
                            } else {
                                saveAd()
                            }

                        }

                    },
                    error: function () {
                        toastr.error("حد خطأ ما");
                    }
                });
            }
            else {
                $(".states-list").html("");
            }

        });
    }
    function addStateEventAction() {
        $('.sub-state-list-item').click(function () {
            advertismentDetails.StateId = this.dataset.index;
            saveAd()
        })
    }
    function resetForm() {

        var inputs = $('.category-specification-details').find('input');
        var selects = $('.category-specification-details').find('select');
        var tereas = $('.category-specification-details').find('textarea');

        var adDetailsInput = $('.advertisment-details').find('input');
        var adDetailsTE = $('.advertisment-details').find('textarea');

        $('.file-image').parent().remove();

        for (var i = 0; i < adDetailsInput.length; i++) {
            if (adDetailsInput[i].value != userPhone)
            adDetailsInput[i].value = '';
        }

        for (var i = 0; i < selects.length; i++) {
            selects[i].value = '';
        }

        for (var i = 0; i < adDetailsTE.length; i++) {
            adDetailsTE[i].value = '';
        }
        advertismentDetails = {};
    }
    function saveAd() {
        spinner.show()
        var inputs = $('.category-specification-details').find('input');
        var selects = $('.category-specification-details').find('select');
        var tereas = $('.category-specification-details').find('textarea');

        var adDetailsInput = $('.advertisment-details').find('input');
        var adDetailsTE = $('.advertisment-details').find('textarea');


        //if (dfieldsList.length > 0)
        //    advertismentDetails['CustomFields'] = dfieldsList
        // add ad details
        for (var i = 0; i < adDetailsInput.length; i++) {
            var d = adDetailsInput[i];
            if (d.value != '') {
                advertismentDetails[d.name] = d.value;
            }
        }

        // add ad details
        for (var i = 0; i < adDetailsTE.length; i++) {
            var d = adDetailsTE[i];
            if (d.value != '') {
                advertismentDetails[d.name] = d.value;
            }
        }

        var images = $('.file-image');
        var imagesList = [];

        for (var i = 0; i < images.length; i++) {
            if (images[i].getAttribute('img-id') != '0') {
                imagesList.push({ Id: images[i].getAttribute('img-id'), Url: '' })
            }
        }
        advertismentDetails['Images'] = imagesList;

        if (advertismentDetails['CategoryId'] == null) {
            toastr.error("Please Choose Categoy");
            spinner.hide()
            return false;
        }
        if (advertismentDetails['CityId'] == null) {
            toastr.error("Please Choose City");
            spinner.hide()

            return false;
        }
         
        advertismentDetails["LocationLongtude"] = 0;
        advertismentDetails["LocationLatitude"] = 0;
        advertismentDetails["UserId"] = '';
        advertismentDetails["Email"] = '';

        //$.post('/Api/Ad/AddAdvertismnt', JSON.stringify(advertismentDetails))
        //    .done(function (response, status, jqxhr) {
        //        toastr.success('Added Successfully')

        //        console.log(response)
        //        $('.sw-btn-next').click();
        //        $('.sw-btn-next').hide();
        //        $('.sw-btn-prev').hide();
        //    })
        //    .fail(function (jqxhr, status, error) {

        //    })
        $('#show-sw').click();

        $.ajax({
            url: '/Api/Ad/AddAdvertismnt',
            type: "POST",
            data: JSON.stringify(advertismentDetails),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            processData: false,
            success: function (result) {
                $('#hide-sw').click();
                if (result.status == 'false') {
                    toastr.error(language == "ar"?"لم يتم إضافة الاعلان حاول مره اخري" : "Failed to add the Ad, Please try again")
                    spinner.hide()

                    return false;
                } else {
                    toastr.success('Added Successfully')
                    if (result.id) {
                        $('.sw-btn-next').click();
                        $('.sw-btn-next').hide();
                        $('.sw-btn-prev').hide();
                        resetForm();
                        window.location = `/Details/${result.id}`;
                    }
                    spinner.hide()


                }
            },
            error: function (xhr) {
                //$('#submit').attr('disabled', false);
            }
        });

    }
    function show(message) {
        $.confirm({
            title: language == "ar"? "معلومات" : "Info",
            content: message,
            icon: 'fa fa-smile-o',
            theme: 'modern',
            closeIcon: true,
            animation: 'scale',
            type: 'blue',
        });
    }

    $(document).ready(function () {

        $('#show-sw').click(function () {
            $('#smartwizard').smartWizard("loader", "show");
        });

        $('#hide-sw').click(function () {
            $('#smartwizard').smartWizard("loader", "hide");
        }); 

        $('#smartwizard').smartWizard({
            selected: 0,
            theme: 'dots',
            autoAdjustHeight: true,
            transitionEffect: 'fade',
            showStepURLhash: false,
            lang: {
                next: nextText,
                previous: prevText
            }
        });

        $('.open-ad-modal').click(function () {
            spinner.show();

            $('#add-ad-modal').modal({
                show: true
            });
             
            setTimeout(function () {
                $('#smartwizard').smartWizard('reset');// go to step 3....
                $('#smartwizard').smartWizard('stepState', [0, 1, 2, 3, 4, 5], 'enable');// go to step 3....
                $('.tab-content').css({ height: 'auto' });
                $('.sub-category-list').html('');
                $('.third-sub-category-list').html('');
                $('.forth-sub-category-list').html('');
                $('.fifth-sub-category-list').html('');
                $('.sixth-sub-category-list').html('');
                $('.sw-btn-next').hide();
                $('.sw-btn-prev').hide(); 
                resetForm();
            }, 250);
            spinner.hide();

        });

        // save ad custom fields
        $('.save-ad-sp').click(function () {
            $('.sw-btn-next').click();
        })
        // Initialize the showStep event
        $("#smartwizard").on("leaveStep", function (e, anchorObject, stepIndex, stepDirection) {
            try {

                if (stepIndex == 2) {
                    var validation = ValidateSP()
                    if (validation.errors == false) {
                        toastr.error(makesurecompletedText);

                        return false;
                    } else {
                        advertismentDetails['CustomFields'] = validation.dfieldsList;
                    }
                }

            } catch {
                toastr.info(wrefreshpage)
                return false;
            }
        });
        // Initialize the showStep event
        $("#smartwizard").on("showStep", function (e, anchorObject, stepIndex, stepDirection) {
            setTimeout(function () {
                $('.tab-content').css({ height: 'auto' });

            }, 1150);

            if (stepIndex == 5) {
                $('#smartwizard').smartWizard('stepState', [0, 1, 2, 3, 4], 'disable');
            }
        });
        // save photos
        $('.save-photos').click(function () {

            var imgsIdsarray = [];
            $('.file-image').each(function () {
                var imgid = parseInt($(this).attr('img-id'));
                if (imgid > 0) {
                    imgsIdsarray.push(imgid);
                }
            });

            if (imgsIdsarray.length <= 0) {
                toastr.error(pleaseaddphotoText);

                return false;
            } else {
                $('.sw-btn-next').click();
            }
        });
        // goto a specific step
        $(document).on('click', '#categories-add-ad-main  .category-pop-select', function () {
            debugger;
            var index = this.dataset['index'];
            spinner.show();
            //$.get('/Api/Category')
            $.get(`/Api/Category/GetSubCategoriesList/${index}`, function (data) {
                if (data != null) {
                    if (data.length > 0) {
                        var html = _.map(data, function (obj) {
                            return `<a href="#" class="list-group-item list-group-item-action sub-category-list-item" data-index="${obj.Id}">${language == 'ar' ? obj.ArabicDescription : obj.EnglishDescription}</a>`
                        })
                        $('.sub-category-list').html(html);
                        $('#smartwizard').smartWizard("stepState", [1], "enable");

                        $('.sw-btn-next').click();
                        spinner.hide();
                        addSubMenuEventAction();

                    } else {
                        advertismentDetails.CategoryId = index;
                        // Disable step
                        spinner.hide();

                        $('#smartwizard').smartWizard("stepState", [1], "disable");
                        $('.sw-btn-next').click();
                    }

                } else {

                }

            })
            // Disable step
            spinner.hide();
        })

        $('.add-file').change(function () {
            var input = $(this);
            var file = this.files;
            console.log(this.files)
            var hasInvalidFiles = false;
            for (var i = 0; i < this.files.length; i++) {
                var file = this.files[i];

                if (!file.type.startsWith('image') && !file.type.startsWith('video')) {
                    hasInvalidFiles = true;
                }
            }

            if (hasInvalidFiles) {
                file.value = "";
                toastr.error(language == "ar" ? "تم اختيار صيغه ملف غير مدعومه" : "Unsupported file selected.");
                return false;
            }
            var currentFilesCount = $('.file-image');
            var counterLimit = this.files.length > (8 - currentFilesCount.length) ? (8 - currentFilesCount.length) : this.files.length;

            spinner.show();

            for (var i = 0; i < counterLimit; i++) {
                var file = this.files[i];
                var reader = new FileReader();
                var formdata = new FormData();
                // adding the file
                formdata.append("image", file);

                var encodedImage = '';
                reader.onloadend = function () {
                    encodedImage = reader.result;
                }

                if (file) {
                    reader.readAsDataURL(file);

                    $.ajax({
                        url: baseUrl + '/Api/ImageUpload/AddAdvertismentImage',
                        type: "POST",
                        data: formdata,
                        processData: false,
                        contentType: false,
                        success: function (result) {
                            $('.images-container').append(
                                `<div class="col-3 imgBoxPro">
                                    <input type="hidden" name="" multiple value="" img-id="${result.id}"  class="file-image">
                                    <div class="addImgpro fram" style="color: red;
                                        font-size: 20px;
                                text-align: right !important;
                                padding-top: 5px; padding-right: 7px;
                                background-size: cover;
                                height: 160px;
                                background-image: url('${baseUrl}/Api/ImageUpload/i?url=${result.url}&type=2')">
                                <i class="fa fa-times remove-image" aria-hidden="true"></i>

                            </div>

                         </div>`);
                            spinner.hide();
                        },
                        error: function (xhr) {
                            //$('#submit').attr('disabled', false);
                        }
                    });
                }
            }


        });

        $(document).on('click', '.remove-image', function () {
            $(this).parent().parent().remove();
        });
        $(document).on('click', '.list-group-item', function () {
            var _self = $(this);
            var parent = _self.parent();
            parent.find('.list-group-item').each(function (i, element) {
                $(element).removeClass('active');
            });
            _self.addClass('active');
        })

        // load cities
        $.ajax({
            type: "get",
            //url: '/Api/CountryApi/GetActiveCities/' + country,
            url: '/Api/CountryApi/GetActiveCities',
            data: { country: country},
            success: function (data) {
                if (data != null) {
                    if (data.status == true) {
                        console.log(data)
                        var html = _.map(data.citiesMapped, function (obj) {
                            return `<a href="#" class="list-group-item list-group-item-action  city-list-item" data-index="${obj.Id}">${language == 'ar' ? obj.NameAr : obj.NameEn}</a>`
                        })
                        $(".city-list").html(html);
                        setCitySelectList();
                    }
                }
            },
            error: function () {
                //toastr.error("حد خطأ ما");
            }
        });
    });
}