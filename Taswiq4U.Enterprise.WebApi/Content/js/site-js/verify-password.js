
$(document).ready(function () {
    $('.resend-code').click(function () {
        $.ajax({
            url: `/@country/@language/ResendVerifyCode?phone=@phone&t=1`,
            method: 'post',
            success: function (data) {
                if (data.status == true) {
                    var waitingTime = 1000 * 4;

                    toastr.success('@successMessageResend', 'Success');

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
                    toastr.error('@errorMessageResend', 'Invalid')
            }
        })
    })
    $("input[name=Phone1]").keyup(function () {
        var next = this.getAttribute('next');
        if (isNaN(this.value)) {
            this.value = '';
            return false;
        }
        if (this.value.length > 1) {
            this.value = '';
            return false;
        }

        if (next == 0) {
            var token = '';
            $("input[name=Phone1]").each(function (i, m) {
                token = m.value + token;
            });
            $.ajax({
                url: `/@country/@language/VerifyForgetPasswordPost?token=${token}&phone=@phone`,
                method: 'post',
                success: function (data) {
                    if (data.status == true) {
                        toastr.success('@successMessage', 'Success');
                        $('#data-post').submit();
                    }
                    else
                        toastr.error('@errorMessage', 'Invalid')
                }
            })
            return false;
        }
        $(`.phone${next}`).val('');
        $(`.phone${next}`).focus();
    })
});