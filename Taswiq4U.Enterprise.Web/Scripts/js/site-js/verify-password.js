
function vp(country, language, phone, successMessageResend, errorMessageResend, successMessage, errorMessage) {
    $(document).ready(function () {
        $('.resend-code').click(function () {
            $.ajax({
                url: `/ResendVerifyCode?phone=${phone}&t=1`,
                method: 'post',
                success: function (data) {
                    if (data.status == true) {
                        var waitingTime = 1000 * 180;

                        toastr.success(successMessageResend, 'Success');

                        $('.counter').show();
                        var time = waitingTime;

                        var timer = setInterval(function () {
                            time = time - 1000;
                            $('.counter span').html(time / 1000);
                        }, 1000);

                        $('.resend-code').hide();
                        var timeout = setTimeout(function () {
                            $('.resend-code').show();
                            $('.counter').hide();
                            $('.counter span').html(0);
                            clearInterval(timer);
                        }, waitingTime);
                        // clear time out
                        // clearTimeout(timeout);
                    }
                    else
                        toastr.error(errorMessageResend, 'Invalid')
                }
            })
        })

        $(".confirm-code").click(function () {
            var code = $(".code");
            if (isNaN(code.val())) {
                code.val('');
                toastr.error('Not valid')
                return false;
            }
            if (code.val().length == 0) {
                toastr.error('Not valid')

                return false;
            }
            $.ajax({
                url: `/VerifyForgetPasswordPost?token=${code.val()}&phone=${phone}`,
                method: 'post',
                success: function (data) {
                    if (data.status == true) {
                        toastr.success(successMessage, 'Success');
                        $('#data-post').submit();
                    }
                    else
                        toastr.error(errorMessage, 'Invalid')
                }
            })

        }) 
    });
}