$(document).ready(function() { 

    // Paragraph Dots
    $(".dots").click(function() { 
        $(".more").toggle();
    })

    // Tooltip
    $('[data-toggle="tooltip"]').tooltip();

    //Trigger Nice Scroll
	//$('.modal-body , .modal.advSubTypesModal .allSubTypes .advTitle, .modal.advSubTypesModal .allSubTypes .advSubTitle, .modal.advSubTypesModal .allSubTypes .advSubSubTitle').niceScroll({
    // $('.modal.advSubTypesModal .allSubTypes .advTitle').niceScroll(".modal.advSubTypesModal .allSubTypes .advTitle ul",{
	// 	cursorcolor: 'red' ,
	// 	cursorwidth: '7px' ,
	// 	cursorfixedheight: 100 ,
	// 	cursorborder: '1px solid #aaa' ,
    //     cursorborderradius: '5px'
    // });

    //Cashing The Scroll Top Element
	var scrollButton = $(".scroll-top");
	$(window).scroll(function () {
        if($(this).scrollTop()>=700){ scrollButton.show(); }	
        else { scrollButton.hide();}
	});
	//Click On Button To Scroll Top
	scrollButton.click(function () {
		$("html,body").animate({scrollTop: 0}, 600);
    });
    
    /* Nav */
	$(window).scroll(function(){
		var scroll = $(window).scrollTop();
		if (scroll > 100) {
			$(".nav").css({"box-shadow":"0px 5px 11px 0px rgba(50, 50, 50, 0.08)", "position":"fixed" , "top":"0" , "z-index":"999", "background":"#fff", "width":"100%", "margin":"0" , "padding":"0 50px"});
        }
		else{
            $(".nav").css({"box-shadow":"none", "position":"static" , "top":"auto" , "margin":"0 50px" , "width":"auto" , "padding":"0" });
		}
	});
    
    // Advertisement Slider SetInterval
    //setInterval(displayNextImage, 3000);
    $("body").onload = function(){
        function changeImage(){
            var img = $(".adv-slider img");
            img.src = images[x];
            x++;
    
            if(x >= images.length){
                x = 0;
            } 
    
            fadeImg(img, 100, true);
            setTimeout("changeImage()", 30000);
        }
    
        function fadeImg(el, val, fade){
            if(fade === true){
                val--;
            }else{
                val ++;
            }
    
            if(val > 0 && val < 100){
                el.style.opacity = val / 100;
                setTimeout(function(){fadeImg(el, val, fade);}, 10);
            }
        }
    
        var images = [],
        x = 0;
    
        images[0] = "../images/adv slider/left-1.jpg";
        images[1] = "../images/adv slider/right-1.jpg";
        images[2] = "../images/adv slider/left-2.jpg";
        images[3] = "../images/adv slider/middle.jpg";
        images[4] = "../images/adv slider/right-2.jpg";
        setTimeout("changeImage()", 30000);
    }

    $(".form-control").on("focus",function(){
        $(this).css("border","3px solid #ddd")
    });

    $(".form-control").on("blur",function(){
        $(this).css("border","1px solid #ccc")
    });

    $('input[type="text"]').on("focus",function(){
        $(".informMessg").css("display","block");
    });

    $('input[type="text"]').on("blur",function(){
        $(".informMessg").css("display","none");
    });

    $('input[type="text"]').on("keyup",function(){

        $(".informMessg").css("display","none");

        var charNum = $(".countCharacter strong"),
            newNum  = (40 - this.value.length),
            newNumTxt = charNum.text(newNum);

        $(this).on("keypress",function(e){
            if(newNum <= 0 ){
                e.preventDefault(); 
            }
            // else {
            //     return true;
            // }
        });

    });

    $('#advTypes').on("focus",function(){
        $(this).attr("data-toggle","modal");
        $(this).attr("data-target",".advTypesModal");
    });

    $('#pencil').click("focus", function () {
        $(this).attr("data-toggle", "modal");
        $(this).attr("data-target", ".advTypesModal");
    });

    
    $(".modal.advTypesModal .type").on("click", function(){
        console.log($(this).html());
        
        $(this).attr("data-dismiss","modal");
        // Show Loading
        $(".generalLoading").css("display","block");
            setTimeout(
                function() {
                    $(".generalLoading").css("display","none");
                }, 1000);
        $(this).attr({"data-toggle":"modal" , "data-target":".advSubTypesModal"});
        
    });

    $(".modal.advSubTypesModal .allSubTypes .advTitle ul li a").on("click",function(element){
        $(".modal.advSubTypesModal h3.subTitleHding").css("display","block");
        $(".modal.advSubTypesModal h3.subTitleHding").text($(this).text());
        $(".modal.advSubTypesModal .allSubTypes .advSubTitle ul").css("display","block");
    });

    $(".modal.advSubTypesModal .allSubTypes .advSubTitle ul li a").on("click",function(element){
        $(".modal.advSubTypesModal h3.subSubTitleHding").css("display","block");
        $(".modal.advSubTypesModal h3.subSubTitleHding").text($(this).text());
        $(".modal.advSubTypesModal .allSubTypes .advSubSubTitle ul").css("display","block");
        //$(".modal.advSubTypesModal .advSubHeading").addClass("active");
        //$(".modal.advSubTypesModal .advSubTitle").addClass("active");
    });

    $(".modal.advSubTypesModal .allSubTypes .advSubSubTitle ul li a").on("click",function(element){
        var blockContent = $(".modal.advTypesModal .type").html();
        $(this).attr("data-dismiss","modal"); 
        $(".add_advertise .contnt .Inpt").css("display", "none");
        $("#advTypes").css("display", "none");
        //$(".add_advertise .contnt .Display").css("display","block");
        //$(".add_advertise .contnt .Display").prepend(blockContent);
        $("#pencildiv").css("display", "block");
        $("pencildiv").prepend(blockContent);
        
    });

    $(".add_advertise .contnt .Display i.fa-pencil").on("click",function(){
        $(this).attr("data-toggle","modal");
        $(this).attr("data-target",".advTypesModal");
    });

    $(".form-control#advTitle").on("blur",function(){
        console.log($(this).val());
        if($(this).val().length > 0){
            $(".add_advertise .contnt .preview").css("display","block");
            $(".add_advertise .contnt .preview h4").text($(this).val()); 
        }
        else{
            $(".add_advertise .contnt .preview").css("display","none");
            $(".add_advertise .contnt .preview h4").text(null);    
        }
    });

    $(".form-control#price").on("blur",function(){
        if($(this).val().length >= 0){
            $(".add_advertise .contnt .preview span.cost").text($(this).val() + " جنيه"); 
        }
        else{
            $(".add_advertise .contnt .preview span.cost").text("0 جنيه");    
        }
    })

});

// Upload Image function
function uploadImg(element){

    // Variables
    var $file = $("#" + element.id + ' input[type="file"]'),
        $loading = $("#" + element.id + " .loading"),
        $putImg = $("#" + element.id + " .putImg"),
        $cancel = $("#" + element.id + " .cancel"),
        $inputBlck = $("#" + element.id + " .inputBlck i"),
        revokUrl =null; 
        
    // Change in Input File
    $file.on('change', function(event){
        // show loader
        $loading.css("display","flex");
        // load img
        $urlPath = URL.createObjectURL(event.target.files[0]);
        revokUrl=$urlPath;
        $putImg.css('border','5px solid #f6f4f4');
        $("#" + element.id +' .putImg img').attr('src',$urlPath);
        $inputBlck.css("display","none");
    });

    // hide loading and show img
    $("#" + element.id +' .putImg img').on('load', function () {
        setTimeout(
            function() {
                $loading.css("display","none");
                $putImg.css("display","block");
            }, 1000);        
    });

    // set preview img
    $('#block1 .putImg img').on('load', function () {
        setTimeout(
            function() {
                $(".add_advertise .contnt .preview .frstImg img").attr("src",revokUrl);
            }, 1000);       
    });

    // Hover on Image Block and Cancel
    $putImg.on('mouseover', function(){
        $cancel.css("display","block");
    })
    $putImg.on('mouseout', function(){
        $cancel.css("display","none");
    })
    $cancel.on('mouseover', function(){
        $cancel.css("display","block");
    })
    $cancel.on('mouseout', function(){
        $cancel.css("display","none");
    })

    // Click on Cancel 
    $cancel.on('click',function(){
        $cancel.css("display","none");
        $putImg.css("display","none");
        $inputBlck.css("display","block");
        $file.val(null);
    })

    // click on cancel for Image1
    $('.uploads .upload_blck#block1 .cancel').on('click', function () {
        $(".add_advertise .contnt .preview .frstImg img").attr("src","http://calgarypma.ca/wp-content/uploads/2018/01/default-thumbnail.jpg");       
    });
}

// Form Validation
function validateForm(){
    var typeRadio = document.forms["Form"]["typeRadio"].value,
        advTitle = document.forms["Form"]["advTitle"].value,
        price = document.forms["Form"]["price"].value,
        governrate = document.forms["Form"]["governrate"].value,
        city = document.forms["Form"]["city"].value,
        phone = document.forms["Form"]["phone"].value,
        accept = document.forms["Form"]["accept"].value;

        if(typeRadio == null || advTitle == null || price == null || governrate == null || city == null || phone == null || accept == null){
            alert("Please Fill All Required Field");
            return false;
        }
}