$(document).ready(function() {
	
	//check if mobile
		var isMobile = false; //initiate as false
		// device detection
		if(/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent) 
			|| /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0,4))) isMobile = true;
	//-
	if (isMobile) {$('body').addClass('mobile');}
	
	
	$('input[name="tel"]').mask("+7 (999) 999-99-99");

	//select 2
	if ($('select').length) {
		$('select').select2({
		  minimumResultsForSearch: Infinity
		});
	}
	//--

	//checkboxes
	if ($('input[type="radio"]').length) {
		$('input[type="radio"]').ezMark();
	}
	
	if ($('input[type="checkbox"]').length) {
		$('input[type="checkbox"]').ezMark();
	}
	//--

	//mobile-menu-toggler
	$('.mobile-menu-toggler').click(function() {
		$('.mobile-menu-toggler').toggleClass('active');
		$('.mobile-menu').toggleClass('active');
		$('body').toggleClass('mobile-menu-open');
	});

	$('.mobile-menu-container .close-button').click(function() {
		$('.mobile-menu-toggler').toggleClass('active');
		$('.mobile-menu').toggleClass('active');
		$('body').toggleClass('mobile-menu-open');
	});
	//--

	//datepicker
	
	$.datepicker.regional['ru'] = {
		closeText: 'Закрыть',
		prevText: 'Предыдущий',
		nextText: 'Следующий',
		currentText: 'Сегодня',
		monthNames: ['Январь','Февраль','Март','Апрель','Май','Июнь','Июль','Август','Сентябрь','Октябрь','Ноябрь','Декабрь'],
		monthNamesShort: ['Янв','Фев','Мар','Апр','Май','Июн','Июл','Авг','Сен','Окт','Ноя','Дек'],
		dayNames: ['воскресенье','понедельник','вторник','среда','четверг','пятница','суббота'],
		dayNamesShort: ['вск','пнд','втр','срд','чтв','птн','сбт'],
		dayNamesMin: ['Вс','Пн','Вт','Ср','Чт','Пт','Сб'],
		weekHeader: 'Не',
		dateFormat: 'dd.mm.yy',
		firstDay: 1,
		isRTL: false,
		showMonthAfterYear: false,
		yearSuffix: ''
	};
	$.datepicker.setDefaults($.datepicker.regional['ru']);

	
	$(".top-banner-calendar-item").datepicker({
		showOtherMonths: true,
		onSelect: function(date){
			$('#datepicker_value').val(date);
		}
	});

	$(".top-banner-calendar-item").datepicker("setDate", $('#datepicker_value').val());

	//--

	//range no ui slider
		if ($('#filter-range1').length) {
	
			var nouislider1 = document.getElementById('filter-range1');
	
			noUiSlider.create(nouislider1, {
				start: [0, 36575],
				connect: true,
				animate: false,						
				range: {
					'min': 0,
					'max': 100000
				}
			});
			
			nouislider1.noUiSlider.on('update', function ( values, handle ) {

				$($('.range-from')).html(parseFloat(nouislider1.noUiSlider.get()[0]).toFixed(0));
				$($('.range-to')).html(parseFloat(nouislider1.noUiSlider.get()[1]).toFixed(0));			
			
			});
			
		}
	//--

	if ($('.wow').length) {
		new WOW().init();
	}		

	//close modal on ESC keypress
	document.addEventListener('keydown', function(e) {
	    var keyCode = e.keyCode;	   
	    if (keyCode === 27) {
	      $.fancybox.close();	      
	    }
	});
	//--

	//header dropdowns
	$('.header-dropdown-toggler').click(function() {
		$('.header-dropdown-wrap').not($(this).closest('.header-dropdown-wrap')).removeClass('show');
		$(this).closest('.header-dropdown-wrap').toggleClass('show');		
	});

	$('.header-dropdown-close').click(function() {
		$(this).closest('.header-dropdown-wrap').removeClass('show');
	});

	$('.header-lang-menu li a').click(function(e) {
		e.preventDefault();
		$('.header-lang-menu li').removeClass('active');
		$(this).closest('li').addClass('active');

		$('.header-lang-head ul li').removeClass('active');
		$('.header-lang-head ul li:nth-child(' + (parseInt($(this).closest('li').index('.header-lang-menu li'))+1) + ')').addClass('active');	
		
		$(this).closest('.header-dropdown-wrap').toggleClass('show');
	});

	$('.currency-menu li a').click(function(e) {
		e.preventDefault();
		$('.currency-menu li').removeClass('active');
		$(this).closest('li').addClass('active');

		$('.currency-head ul li').removeClass('active');
		$('.currency-head ul li:nth-child(' + (parseInt($(this).closest('li').index('.currency-menu li'))+1) + ')').addClass('active');	
		
		$(this).closest('.header-dropdown-wrap').toggleClass('show');
	});

	$('.header-country-menu li a').click(function(e) {
		e.preventDefault();
		$('.header-country-menu li').removeClass('active');
		$(this).closest('li').addClass('active');

		$('.header-country-head ul li').removeClass('active');
		$('.header-country-head ul li:nth-child(' + (parseInt($(this).closest('li').index('.header-country-menu li'))+1) + ')').addClass('active');	
		
		$(this).closest('.header-dropdown-wrap').toggleClass('show');
	});

	$('.chat-button').click(function() {
		$.fancybox.open({src:"#notification-popup"});
	});
	//--
	
	//Sliders

	if ($(".slider").length) {
				var n_slides = 4;
				if ($(window).width() < 1240) {n_slides = 2;}	
				if ($(window).width() < 768) {n_slides = 1;}			

				$('.slider').each(function() {
					if ($(this).hasClass('second-slider')) {n_slides = 1;}

					$(this).slick({
						slidesToShow: n_slides,
						slidesToScroll: 1,
						arrows: true,
						dots: false,
						autoplay: false,
						infinite:true,
						autoplaySpeed: 4000,
						slide: ".slider-item",				    			    
						//swipeToSlide: true,
						variableWidth: true,
						touchThreshold: 25,
						useTransforms: false,
						useCSS: false	    
					});
				});
				 
	}

	if ($(".persons-slider").length) {
		var n_slides = 4;
		if ($(window).width() < 1240) {n_slides = 2;}	
		if ($(window).width() < 768) {n_slides = 1;}			

		$('.persons-slider').each(function() {
			$(this).slick({
				slidesToShow: n_slides,
				slidesToScroll: 1,
				arrows: true,
				dots: false,
				autoplay: false,
				infinite:true,
				autoplaySpeed: 4000,
				slide: ".persons-item",				    			    
				//swipeToSlide: true,
				variableWidth: true,
				touchThreshold: 25,
				useTransforms: false,
				useCSS: false	    
			});
		});
		 
}

	//--



	//the tabs
	setTimeout(function() {
		$('.the-tabs-item').not('.the-tabs-item.active').slideUp(0);
	}, 1000);
	
	$('.the-tabs-head button').click(function(e) {
		e.preventDefault();
		$('.the-tabs-item').removeClass('active').slideUp(0);				
		$('.the-tabs-item:nth-child('+(parseInt($(this).index('.the-tabs-head button'))+1)+')').addClass('active').slideDown(0);
		
		$('.the-tabs-head button').removeClass('active');
		$(this).addClass('active');
	});
	//-
	
	//toggler mechanics
	$('.toggling_item').addClass('closed');

	$('.toggler').click(function(e) {
		e.preventDefault();
		$(this).toggleClass('active');
		if ($(this).hasClass('active')) {$(this).html($(this).data('close'));} else {$(this).html($(this).data('open'));}

		$(this).closest('div').find('.toggling_item').toggleClass('closed');
	});
	//--


	$('.fancy').fancybox({
		nextSpeed:0,
		prevSpeed:0,
		'afterShow': function() {
			 
		},
		'beforeClose': function() {
			if ($('select').length) {	
				for (var i=0;i<slbox.length;i++) {
					slbox[i].hideMenus();
				}
			}
		}
	});

	$('.fancy_img').fancybox({
		loop:true
	});






	

	//window scroll

	$.fn.isFullyInViewport = function() {
      var elementTop = $(this).offset().top;
      var elementBottom = elementTop + $(this).outerHeight();

      var viewportTop = $(window).scrollTop();
      var viewportBottom = viewportTop + $(window).height();

      return viewportTop >= elementTop && viewportTop <= elementBottom;
    };

	
	var fromTop = 0;
	
	$(window).scroll(function() {
		
		fromTop=$(window).scrollTop();
		 
		if (fromTop > 10) {$('header').addClass('active');}
		if (fromTop < 10) {$('header').removeClass('active').removeClass('open');}
		 
		
		if (fromTop > 700) {$('a.to-top').addClass('active');}
		if (fromTop < 700) {$('a.to-top').removeClass('active');}

	});
	
	//-

	//contacts map
	if ($('#map').length) {
			
		ymaps.ready(init);
 
		function init () {
			// Создание экземпляра карты и его привязка к контейнеру с
			// заданным id ("contacts_map")
			var myMap = new ymaps.Map('map', {
					// При инициализации карты, обязательно нужно указать
					// ее центр и коэффициент масштабирования
					center: [55.759457, 37.436426], 
					zoom: 16
				});

			// Создание макета содержимого балуна.
			// Макет создается с помощью фабрики макетов с помощью текстового шаблона.
			BalloonContentLayout = ymaps.templateLayoutFactory.createClass(
				'<div class="my_balloon">' +
					'<p>{{properties.name}}</p>' +
				'</div>', {

				// Переопределяем функцию build, чтобы при создании макета начинать
				// слушать событие click на кнопке-счетчике.
				build: function () {
					// Сначала вызываем метод build родительского класса.
					BalloonContentLayout.superclass.build.call(this);
				   
				},

				// Аналогично переопределяем функцию clear, чтобы снять
				// прослушивание клика при удалении макета с карты.
				clear: function () {
					// Выполняем действия в обратном порядке - сначала снимаем слушателя,
					// а потом вызываем метод clear родительского класса.
					
					BalloonContentLayout.superclass.clear.call(this);
				}
				
			});

			// Создание метки 
				myPlacemark1 = new ymaps.Placemark([55.759457, 37.436426], {
					name: 'парк Крылатские холмы'
				}, {
					balloonContentLayout: BalloonContentLayout,				            
					balloonPanelMaxMapArea: 0
				});
				// Добавление метки на карту
				myMap.geoObjects.add(myPlacemark1);
				//myPlacemark1.options.set('iconLayout', 'default#image');						
				//myPlacemark1.options.set('iconImageHref', './img/placemark.png');
				//myPlacemark1.options.set('iconImageSize', [30,46]);
				//myPlacemark1.options.set('iconImageOffset', [-15,-46]);
				//myPlacemark1.options.set('hideIconOnBalloonOpen', "false");

				
				
			 myMap.controls.add("zoomControl", {
					position: {top: 35, left: 15}
			 });

			 myMap.behaviors.disable('scrollZoom');
			
		}
}

	

	//elements rearrangement on mobile
	var once = true;

	function fillMobileMenu() {
		if ($(window).width() <= 1100) {
			if (once) {
				//$('.header-icons-block').clone().appendTo('.mobile-menu-container .mobile-container-top-panel');
				$('.footer_right').clone().appendTo('.mobile-menu-container');	
				$('.header-menu_wrap').clone().appendTo('.mobile-menu-container .mobile-container-header-menu');

				$('.header-lang').appendTo('.mobile-menu-container .mobile-container-lang');
				$('.header-country').appendTo('.mobile-menu-container .mobile-container-country');

				once = false;
			}
		}
	}

	setTimeout(fillMobileMenu,1000);


	if ($(window).width() < 1170) {


	}
	
	if ($(window).width() < 1024) {


	}

	if (($(window).width() < 1024) && ($(window).width() > 767)) {
		

	}

	if ($(window).width() < 768) {
		
		$('.the-form-item-submit').appendTo($('.the-form-item-submit').closest('form'));

	}
	//--
	
	
	
	
	
	//scroll to
	
		$('.header-menu li a').click(function() {
			
			$('.mobile-menu-toggler').toggleClass('active');
			$('.mobile-menu').toggleClass('active');
			$('body').toggleClass('mobile-menu-open');

			$("html, body").animate({
            scrollTop: ($($(this).attr("href")).offset().top) + "px"
			}, {
				duration: 900
			});
			return false;
		});		
	
	//--




 
});