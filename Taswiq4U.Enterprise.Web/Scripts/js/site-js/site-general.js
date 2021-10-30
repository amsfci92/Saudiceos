function s_g_setup(country, addFavUrl, addRemoveFavUrl) {
    $(function () {
        $(".single-cat").click(function () {
            $(".hidden-row").slideToggle(300);
        });

        $(".single-cat1").click(function () {
            $(".hidden-row1").slideToggle(300);
        });
    });

    //spinner
    window.Spinner = function () {
        this.show = function () {
            $('#spinner1').removeClass('spinner-cont-hide').addClass('spinner-cont-show');
        }

        this.hide = function () {
            $('#spinner1').removeClass('spinner-cont-show').addClass('spinner-cont-hide');
        }
    }


    $(document).ready(function () {

        var images = $('.replace-image');
        if (images != null) {
            for (var i = 0; i < images.length; i++) {
                var element = images[i];

                $.get(element.src, function (data) {
                    element.src = data;
                })
            }
        }
    })

    window.sendRequestAjax = function (element) {

        $.get(element.src, function (data) {
            element.src = data;
        })
    }

    window.AjaxHelper = function () {
        this.getRequest = function (url, success, error) {
            $.get({
                url: url,
                success: success,
                error: error
            });
        }
        this.postRequest = function (url, data, success, error) {
            spinner.show()
            $.post({
                url: url,
                data: data,
                dataType: 'text/json',
                success: function (data) {
                    spinner.hide();
                    success(data)
                },
                error: function (err) {
                    spinner.hide();
                    error(err)
                }
            })
        }
    };

    // deals with offers requests
    window.OffersRequests = function () {
        this.ajaxHelper = new AjaxHelper()
        this.baseUrl = '/Offers/',
            this.likeCommercialAd = function (comAdId) {
                this.ajaxHelper.getRequest(`${this.baseUrl}Like/${comAdId}`, function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
            },
            this.incrementViewCount = function (comAdId) {
                this.ajaxHelper.getRequest(`${this.baseUrl}incrementView/${comAdId}`, function (data) {
                    return data;
                }, function (error) {
                    return error;
                });
            },
            this.getRequestData = function (adId, afterLoading) {

                return this.ajaxHelper.getRequest(`${this.baseUrl}GetCommAdData/${adId}`, function (data) {
                    if (afterLoading != null)
                        afterLoading(data);

                })
            },
            this.getPopUpRequestData = function (afterLoading) {

                return this.ajaxHelper.getRequest(`${this.baseUrl}GetCommercialPopUp?country=${country}`, function (data) {
                    if (afterLoading != null)
                        afterLoading(data);
                })
            }
    };

    window.ViewedItemsManager = function () {
        _self = this;
        console.log(this)
        console.log(_self)
        this.id = 0
        this.itemName = 'viewedItems'
        this.parsedViewedItems = []
        this.getAllItems = function () {
            return localStorage.getItem(_self.itemName);
        }
        this.saveAllItems = function () {
            localStorage.removeItem(_self.itemName);
            localStorage.setItem(_self.itemName,
                JSON.stringify(_self.parsedViewedItems));
        }
        this.exists = function () {
            let result = _self.parsedViewedItems.find(function (element) {
                return element == _self.id
            });
            return result != undefined;
        }
        this.addItem = function (id, afterAdding) {
            var viewedItems = _self.getAllItems();
            debugger;
            _self.id = id;
            if (viewedItems != null) {
                _self.parsedViewedItems = JSON.parse(viewedItems);

                if (!_self.exists() && _self.id != '0') {
                    _self.parsedViewedItems.push(_self.id);
                    if (afterAdding != null)
                        afterAdding();
                }
            } else {
                if (_self.id != 0) {
                    if (afterAdding != null)
                        afterAdding();
                    _self.parsedViewedItems.push(_self.id);
                }
            }
            _self.saveAllItems();
        }
    }

    window.AddToFav = function (adId) {
        $.ajax({
            type: "post",
            url: addFavUrl + '?addvertisementId=' + adId,
            success: function (data) {
                //$("#AdQucikView").html(data);
            },
            error: function (data) {
                //$("#AdQucikView").html("");
            }
        });
    }


    $(".add-favorite").click(function () {
        var btn = $(this);
        btn.prop('disabled', true);
        $.ajax({
            type: "post",
            url: `${addRemoveFavUrl}?addvertisementId=${btn.dataset['index']}`,
            success: function (res) {
                btn.prop('disabled', false);
                if (res.data == true) {
                    btn.removeClass('threebuttongreen');
                    btn.addClass('threebuttonred');
                    btn.html('<i class="fa  fa-heart-o" aria-hidden="true"></i>');
                }
                else {
                    btn.removeClass('threebuttonred');
                    btn.addClass('threebuttongreen');
                    btn.html('<i class="fa  fa-heart-o" aria-hidden="true"></i>');
                }
            },
            error: function (data) {
                btn.prop('disabled', false);
                toas.error("حدث خطأ ما");
            }
        });
    });

   
}

// $('.select2').select2();