/*
Template Name: STUDIO ASP - Responsive Bootstrap 5 Admin Template
Version: 4.4.0
Author: Sean Ngu
  ----------------------------
    APPS CONTENT TABLE
  ----------------------------

  <!-- ======== GLOBAL SCRIPT SETTING ======== -->
  01. Global Variable
  02. Handle Scrollbar
  03. Handle Sidebar Menu
  04. Handle Sidebar Minify
  05. Handle Sidebar Minify Float Menu
  06. Handle Dropdown Close Option
  07. Handle Card - Remove / Reload / Collapse / Expand
  08. Handle Tooltip & Popover Activation
  09. Handle Scroll to Top Button Activation
  10. Handle hexToRgba
  11. Handle Scroll to
  12. Handle Theme Panel Expand
  13. Handle Theme Page Control
  14. Handle Enable Tooltip & Popover
  15. Handle Top Nav - Unlimited Nav Render
  16. Handle Top Nav - Submenu Toggle
  17. Handle Top Nav - Mobile Toggle
	
  <!-- ======== APPLICATION SETTING ======== -->
  Application Controller
*/



/* 01. Global Variable
------------------------------------------------ */
var app = {
	class: 'app',
	isMobile: ((/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) || window.innerWidth < 992),
	header: {
		class: 'app-header'
	},
	sidebar: {
		class: 'app-sidebar',
		menuClass: 'menu',
		menuItemClass: 'menu-item',
		menuItemHasSubClass: 'has-sub',
		menuLinkClass: 'menu-link',
		menuSubmenuClass: 'menu-submenu',
		menuExpandClass: 'expand',
		minify: {
			toggledClass: 'app-sidebar-minified',
			localStorage: 'appSidebarMinified',
			toggleAttr: 'data-toggle="sidebar-minify"'
		},
		mobile: {
			toggledClass: 'app-sidebar-mobile-toggled',
			closedClass: 'app-sidebar-mobile-closed',
			dismissAttr: 'data-dismiss="sidebar-mobile"',
			toggleAttr: 'data-toggle="sidebar-mobile"',
		},
		scrollBar: {
			localStorage: 'appSidebarScrollPosition',
			dom: '',
		}
	},
	floatSubmenu: {
		id: 'app-float-submenu',
		dom: '',
		timeout: '',
		class: 'app-float-submenu',
		container: {
			class: 'app-float-submenu-container'
		},
		overflow: {
			class: 'overflow-scroll mh-100vh'
		}
	},
	topNav: {
		id: '#top-nav',
		class: 'app-top-nav',
		mobile: {
			toggleAttr: 'data-toggle="top-nav-mobile"'
		},
		menu: {
			class: 'menu',
			itemClass: 'menu-item',
			itemLinkClass: 'menu-link',
			activeClass: 'active',
			hasSubClass: 'has-sub',
			expandClass: 'expand',
			submenu: {
				class: 'menu-submenu'
			}
		},
		control: {
			class: 'menu-control',
			startClass: 'menu-control-start',
			endClass: 'menu-control-end',
			showClass: 'show',
			buttonPrev: {
				class: 'menu-control-start',
				toggleAttr: 'data-toggle="top-nav-prev"'
			},
			buttonNext: {
				class: 'menu-control-end',
				toggleAttr: 'data-toggle="top-nav-next"'
			}
		}
	},
	themePanel: {
		class: 'theme-panel',
		toggleAttr: 'data-click="theme-panel-expand"',
		expandCookie: 'theme-panel',
		expandCookieValue: 'expand',
		activeClass: 'active',
		themeList: {
			class: 'theme-list',
			toggleAttr: 'data-theme',
			activeClass: 'active',
			cookieName: 'theme',
			onChangeEvent: 'theme-reload'
		},
		darkMode: {
			class: 'dark-mode',
			inputName: 'app-theme-dark-mode',
			cookieName: 'dark-mode'
		}
	},
	animation: { 
		speed: 300 
	},
	scrollBar: {
		attr: 'data-scrollbar="true"',
		heightAttr: 'data-height',
		skipMobileAttr: 'data-skip-mobile="true"',
		wheelPropagationAttr: 'data-wheel-propagation'
	},
	scrollTo: {
		toggleAttr: 'data-toggle="scroll-to"',
		targetAttr: 'data-target'
	},
	scrollTopButton: {
		toggleAttr: 'data-click="scroll-top"',
		showClass: 'show'
	},
	card: { 
		class: 'card',
		expand: {
			toggleAttr: 'data-toggle="card-expand"',
			status: false,
			class: 'card-expand',
			tooltipText: 'Expand / Compress'
		}
	},
	tooltip: {
		toggleAttr: 'data-bs-toggle="tooltip"'
	},
	popover: {
		toggleAttr: 'data-bs-toggle="popover"'
	},
	dismissClass: {
		toggleAttr: 'data-dismiss-class',
		targetAttr: 'data-dismiss-target'
	},
	toggleClass: {
		toggleAttr: 'data-toggle-class',
		targetAttr: 'data-toggle-target'
	},
	font: { },
	color: { },
	variablePrefix: 'bs-',
	variableFontList: ['body-font-family', 'body-font-size', 'body-font-weight', 'body-line-height'],
	variableColorList: [
		'theme', 'theme-rgb', 'theme-color', 'theme-color-rgb',
		'default', 'default-rgb',
		'primary', 'primary-rgb', 'primary-bg-subtle', 'primary-text', 'primary-border-subtle',
		'secondary', 'secondary-rgb', 'secondary-bg-subtle', 'secondary-text', 'secondary-border-subtle',
		'success', 'success-rgb', 'success-bg-subtle', 'success-text', 'success-border-subtle',
		'warning', 'warning-rgb', 'warning-bg-subtle', 'warning-text', 'warning-border-subtle',
		'info', 'info-rgb', 'info-bg-subtle', 'info-text', 'info-border-subtle',
		'danger', 'danger-rgb', 'danger-bg-subtle', 'danger-text', 'danger-border-subtle',
		'light', 'light-rgb', 'light-bg-subtle', 'light-text', 'light-border-subtle',
		'dark', 'dark-rgb', 'dark-bg-subtle', 'dark-text', 'dark-border-subtle',
		'white', 'white-rgb',
		'black', 'black-rgb',
		'teal', 'teal-rgb',
		'indigo', 'indigo-rgb', 
		'purple', 'purple-rgb',
		'yellow', 'yellow-rgb',
		'pink', 'pink-rgb',
		'cyan', 'cyan-rgb',
		'gray-100', 'gray-200', 'gray-300', 'gray-400', 'gray-500',  'gray-600', 'gray-700', 'gray-800', 'gray-900', 
		'gray-100-rgb', 'gray-200-rgb', 'gray-300-rgb', 'gray-400-rgb', 'gray-500-rgb',  'gray-600-rgb', 'gray-700-rgb', 'gray-800-rgb', 'gray-900-rgb', 
		'muted', 'muted-rgb', 'emphasis-color', 'emphasis-color-rgb',
		'component-bg', 'component-bg-rgb', 'component-color', 'component-color-rgb',
		'body-bg', 'body-bg-rgb', 'body-color', 'body-color-rgb',
		'heading-color', 
		'secondary-color', 'secondary-color-rgb', 'secondary-bg', 'secondary-bg-rgb',
		'tertiary-color', 'tertiary-color-rgb', 'tertiary-bg', 'tertiary-bg-rgb',
		'link-color', 'link-color-rgb', 'link-hover-color', 'link-hover-color-rgb', 
		'border-color', 'border-color-translucent'
	],
}

var slideUp = function(elm, duration = app.animation.speed) {
	if (!elm.classList.contains('transitioning')) {
		elm.classList.add('transitioning');
		elm.style.transitionProperty = 'height, margin, padding';
		elm.style.transitionDuration = duration + 'ms';
		elm.style.boxSizing = 'border-box';
		elm.style.height = elm.offsetHeight + 'px';
		elm.offsetHeight;
		elm.style.overflow = 'hidden';
		elm.style.height = 0;
		elm.style.paddingTop = 0;
		elm.style.paddingBottom = 0;
		elm.style.marginTop = 0;
		elm.style.marginBottom = 0;
		window.setTimeout( () => {
			elm.style.display = 'none';
			elm.style.removeProperty('height');
			elm.style.removeProperty('padding-top');
			elm.style.removeProperty('padding-bottom');
			elm.style.removeProperty('margin-top');
			elm.style.removeProperty('margin-bottom');
			elm.style.removeProperty('overflow');
			elm.style.removeProperty('transition-duration');
			elm.style.removeProperty('transition-property');
			elm.classList.remove('transitioning');
		}, duration);
	}
};

var slideDown = function(elm, duration = app.animation.speed) {
	if (!elm.classList.contains('transitioning')) {
		elm.classList.add('transitioning');
		elm.style.removeProperty('display');
		let display = window.getComputedStyle(elm).display;
		if (display === 'none') display = 'block';
		elm.style.display = display;
		let height = elm.offsetHeight;
		elm.style.overflow = 'hidden';
		elm.style.height = 0;
		elm.style.paddingTop = 0;
		elm.style.paddingBottom = 0;
		elm.style.marginTop = 0;
		elm.style.marginBottom = 0;
		elm.offsetHeight;
		elm.style.boxSizing = 'border-box';
		elm.style.transitionProperty = "height, margin, padding";
		elm.style.transitionDuration = duration + 'ms';
		elm.style.height = height + 'px';
		elm.style.removeProperty('padding-top');
		elm.style.removeProperty('padding-bottom');
		elm.style.removeProperty('margin-top');
		elm.style.removeProperty('margin-bottom');
		window.setTimeout( () => {
			elm.style.removeProperty('height');
			elm.style.removeProperty('overflow');
			elm.style.removeProperty('transition-duration');
			elm.style.removeProperty('transition-property');
			elm.classList.remove('transitioning');
		}, duration);
	}
};

var slideToggle = function(elm, duration = app.animation.speed) {
	if (window.getComputedStyle(elm).display === 'none') {
		return slideDown(elm, duration);
	} else {
		return slideUp(elm, duration);
	}
};

var setCookie = function(cookieName, cookieValue) {
	var now = new Date();
  var time = now.getTime();
  var expireTime = time + 360*24*60*60*1000;
  now.setTime(expireTime);
  document.cookie = cookieName + '='+ cookieValue +';expires='+now.toUTCString()+';path=/';
};

var getCookie = function(cookieName) {
  let name = cookieName + "=";
  let decodedCookie = decodeURIComponent(document.cookie);
  let ca = decodedCookie.split(';');
  for(let i = 0; i <ca.length; i++) {
    let c = ca[i];
    while (c.charAt(0) == ' ') {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
};


/* 02. Handle Scrollbar
------------------------------------------------ */
var handleScrollbar = function() {
	"use strict";
	
	var elms = document.querySelectorAll('['+ app.scrollBar.attr +']');
		
	for (var i = 0; i < elms.length; i++) {
		generateScrollbar(elms[i])
	}
};
var generateScrollbar = function(elm) {
  "use strict";
	
	if (elm.scrollbarInit || (app.isMobile && elm.getAttribute(app.scrollBar.skipMobileAttr))) {
		return;
	}
	var dataHeight = (!elm.getAttribute(app.scrollBar.heightAttr)) ? elm.offsetHeight : elm.getAttribute(app.scrollBar.heightAttr);
	
	elm.style.height = dataHeight;
	elm.scrollbarInit = true;
	
	if(app.isMobile || !PerfectScrollbar) {
		elm.style.overflowX = 'scroll';
	} else {
		var dataWheelPropagation = (elm.getAttribute(app.scrollBar.wheelPropagationAttr)) ? elm.getAttribute(app.scrollBar.wheelPropagationAttr) : false;
		
		if (PerfectScrollbar) {
			if (elm.closest('.'+ app.sidebar.class )) {
				app.sidebar.scrollBarDom = new PerfectScrollbar(elm, {
					wheelPropagation: dataWheelPropagation
				});
			} else {
				new PerfectScrollbar(elm, {
					wheelPropagation: dataWheelPropagation
				});
			}
		}
	}
};


/* 03. Handle Sidebar Menu
------------------------------------------------ */
var handleSidebarMenuToggle = function(menus) {
	menus.map(function(menu) {
		menu.onclick = function(e) {
			e.preventDefault();
			
			var target = this.nextElementSibling;
			
			if (!document.querySelector('.'+ app.sidebar.minify.toggledClass) || window.innerWidth < 992) {
				slideToggle(target);
				
				menus.map(function(m) {
					var otherTarget = m.nextElementSibling;
					if (otherTarget !== target) {
						slideUp(otherTarget);
						otherTarget.closest('.'+ app.sidebar.menuItemClass).classList.remove(app.sidebar.menuExpandClass);
					}
				});
				
				var targetElm = target.closest('.'+ app.sidebar.menuItemClass);
				if (targetElm.classList.contains(app.sidebar.menuExpandClass)) {
					targetElm.classList.remove(app.sidebar.menuExpandClass);
				} else {
					targetElm.classList.add(app.sidebar.menuExpandClass);
				}
			}
		}
	});
};
var handleSidebarMenu = function() {
	"use strict";
	
	var menus = [].slice.call(document.querySelectorAll('.'+ app.sidebar.class +' .'+ app.sidebar.menuClass +' > .'+ app.sidebar.menuItemClass +'.'+ app.sidebar.menuItemHasSubClass +' > .'+ app.sidebar.menuLinkClass +''));
	handleSidebarMenuToggle(menus);
	
	var menus = [].slice.call(document.querySelectorAll('.'+ app.sidebar.class +' .'+ app.sidebar.menuClass +' > .'+ app.sidebar.menuItemClass +'.'+ app.sidebar.menuItemHasSubClass +' .'+ app.sidebar.menuSubmenuClass +' .'+ app.sidebar.menuItemClass +'.'+ app.sidebar.menuItemHasSubClass +' > .'+ app.sidebar.menuLinkClass +''));
	handleSidebarMenuToggle(menus);
};


/* 04. Handle Sidebar Scroll Memory
------------------------------------------------ */
var handleSidebarScrollMemory = function() {
	if (!app.isMobile) {
		try {
			if (typeof(Storage) !== 'undefined' && typeof(localStorage) !== 'undefined') {
				var elm = document.querySelector('.'+ app.sidebar.class +' ['+ app.scrollBar.attr +']');
				
				if (elm) {
					elm.onscroll = function() {
						localStorage.setItem(app.sidebar.scrollBar.localStorage, this.scrollTop);
					}
					var defaultScroll = localStorage.getItem(app.sidebar.scrollBar.localStorage);
					if (defaultScroll) {
						document.querySelector('.'+ app.sidebar.class +' ['+ app.scrollBar.attr +']').scrollTop = defaultScroll;
					}
				}
			}
		} catch (error) {
			console.log(error);
		}
	}
};


/* 05. Handle Sidebar Minify
------------------------------------------------ */
var handleSidebarMinify = function() {
	var elms = [].slice.call(document.querySelectorAll('['+ app.sidebar.minify.toggleAttr +']'));
	elms.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
		
			var targetElm = document.querySelector('.'+ app.class);
			
			if (targetElm) {
				if (targetElm.classList.contains(app.sidebar.minify.toggledClass)) {
					targetElm.classList.remove(app.sidebar.minify.toggledClass);
					localStorage.removeItem(app.sidebar.minify.localStorage);
				} else {
					targetElm.classList.add(app.sidebar.minify.toggledClass);
					localStorage.setItem(app.sidebar.minify.localStorage, true);
				}
			}
		};
	});
	
	if (typeof(Storage) !== 'undefined') {
		if (localStorage[app.sidebar.minify.localStorage]) {
			var targetElm = document.querySelector('.'+ app.class);
			
			if (targetElm) {
				targetElm.classList.add(app.sidebar.minify.toggledClass);
			}
		}
	}
};
var handleSidebarMobileToggle = function() {
	var elms = [].slice.call(document.querySelectorAll('['+ app.sidebar.mobile.toggleAttr +']'));
	
	elms.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			
			var targetElm = document.querySelector('.'+ app.class)
			
			if (targetElm) {
				targetElm.classList.remove(app.sidebar.mobile.closedClass);
				targetElm.classList.add(app.sidebar.mobile.toggledClass);
			}
		};
	});
};
var handleSidebarMobileDismiss = function() {
	var elms = [].slice.call(document.querySelectorAll('['+ app.sidebar.mobile.dismissAttr +']'));
	
	elms.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			
			var targetElm = document.querySelector('.'+ app.class)
			
			if (targetElm) {
				targetElm.classList.remove(app.sidebar.mobile.toggledClass);
				targetElm.classList.add(app.sidebar.mobile.closedClass);
				
				setTimeout(function() {
					targetElm.classList.remove(app.sidebar.mobile.closedClass);
				}, app.animation.speed);
			}
		};
	});
};


/* 06. Handle Sidebar Minify Float Menu
------------------------------------------------ */
var handleGetHiddenMenuHeight = function(elm) {
	elm.setAttribute('style', 'position: absolute; visibility: hidden; display: block !important');
	var targetHeight  = elm.clientHeight;
	elm.removeAttribute('style');
	return targetHeight;
}
var handleSidebarMinifyFloatMenuClick = function() {
	var elms = [].slice.call(document.querySelectorAll('.'+ app.floatSubmenu.class +' .'+ app.sidebar.menuItemClass +'.'+ app.sidebar.menuItemHasSubClass +' > .'+ app.sidebar.menuLinkClass));
	if (elms) {
		elms.map(function(elm) {
			elm.onclick = function(e) {
				e.preventDefault();
				var targetItem = this.closest('.' + app.sidebar.menuItemClass);
				var target = targetItem.querySelector('.' + app.sidebar.menuSubmenuClass);
				var targetStyle = getComputedStyle(target);
				var close = (targetStyle.getPropertyValue('display') != 'none') ? true : false;
				var expand = (targetStyle.getPropertyValue('display') != 'none') ? false : true;
				
				slideToggle(target);
				
				var loopHeight = setInterval(function() {
					var targetMenu = document.querySelector(app.floatSubmenu.id);
					var targetMenuArrow = document.querySelector(app.floatSubmenu.arrow.id);
					var targetMenuLine = document.querySelector(app.floatSubmenu.line.id);
					var targetHeight = targetMenu.clientHeight;
					var targetOffset = targetMenu.getBoundingClientRect();
					var targetOriTop = targetMenu.getAttribute('data-offset-top');
					var targetMenuTop = targetMenu.getAttribute('data-menu-offset-top');
					var targetTop 	 = targetOffset.top;
					var windowHeight = document.body.clientHeight;
					if (close) {
						if (targetTop > targetOriTop) {
							targetTop = (targetTop > targetOriTop) ? targetOriTop : targetTop;
							targetMenu.style.top = targetTop + 'px';
							targetMenu.style.bottom = 'auto';
							targetMenuArrow.style.top = '20px';
							targetMenuArrow.style.bottom = 'auto';
							targetMenuLine.style.top = '20px';
							targetMenuLine.style.bottom = 'auto';
						}
					}
					if (expand) {
						if ((windowHeight - targetTop) < targetHeight) {
							var arrowBottom = (windowHeight - targetMenuTop) - 22;
							targetMenu.style.top = 'auto';
							targetMenu.style.bottom = 0;
							targetMenuArrow.style.top = 'auto';
							targetMenuArrow.style.bottom = arrowBottom + 'px';
							targetMenuLine.style.top = '20px';
							targetMenuLine.style.bottom = arrowBottom + 'px';
						}
						var floatSubmenuElm = document.querySelector(app.floatSubmenu.id + ' .'+ app.floatSubmenu.class);
						if (targetHeight > windowHeight) {
							if (floatSubmenuElm) {
								var splitClass = (app.floatSubmenu.overflow.class).split(' ');
								for (var i = 0; i < splitClass.length; i++) {
									floatSubmenuElm.classList.add(splitClass[i]);
								}
							}
						}
					}
				}, 1);
				setTimeout(function() {
					clearInterval(loopHeight);
				}, app.animation.speed);
			}
		});
	}
}
var handleSidebarMinifyFloatMenu = function() {
	var elms = [].slice.call(document.querySelectorAll('.' + app.sidebar.class + ' .'+ app.sidebar.menuClass +' > .'+ app.sidebar.menuItemClass +'.'+ app.sidebar.menuItemHasSubClass +' > .'+ app.sidebar.menuLinkClass +''));
	if (elms) {
		elms.map(function(elm) {
			elm.onmouseenter = function() {
				var appElm = document.querySelector('.' + app.class);
				
				if (appElm && appElm.classList.contains(app.sidebar.minify.toggledClass) && window.innerWidth >= 992) {
					clearTimeout(app.floatSubmenu.timeout);
					
					var targetMenu = this.closest('.'+ app.sidebar.menuItemClass).querySelector('.' + app.sidebar.menuSubmenuClass);
					if (app.floatSubmenu.dom == this && document.querySelector(app.floatSubmenu.class)) {
						return;
					} else {
						app.floatSubmenu.dom = this;
					}
					var targetMenuHtml = targetMenu.innerHTML;
					if (targetMenuHtml) {
						var bodyStyle     = getComputedStyle(document.body);
						var sidebarOffset = document.querySelector('.'+ app.sidebar.class).getBoundingClientRect();
						var sidebarWidth  = parseInt(document.querySelector('.'+ app.sidebar.class).clientWidth);
						var sidebarX      = (bodyStyle.getPropertyValue('direction') != 'rtl') ? (sidebarOffset.left + sidebarWidth) : (document.body.clientWidth - sidebarOffset.left);
						var targetHeight  = handleGetHiddenMenuHeight(targetMenu);
						var targetOffset  = this.getBoundingClientRect();
						var targetTop     = targetOffset.top;
						var targetLeft    = (bodyStyle.getPropertyValue('direction') != 'rtl') ? sidebarX : 'auto';
						var targetRight   = (bodyStyle.getPropertyValue('direction') != 'rtl') ? 'auto' : sidebarX;
						var windowHeight  = document.body.clientHeight;
						
						if (!document.querySelector('#'+ app.floatSubmenu.id)) {
							var overflowClass = '';
							if (targetHeight > windowHeight) {
								overflowClass = app.floatSubmenu.overflow.class;
							}
							var html = document.createElement('div');
							html.setAttribute('id', app.floatSubmenu.id);
							html.setAttribute('class', app.floatSubmenu.class);
							html.setAttribute('data-offset-top', targetTop);
							html.setAttribute('data-menu-offset-top', targetTop);
							html.innerHTML = ''+
							'	<div class="'+ app.floatSubmenu.container.class +' '+ overflowClass +'">'+ targetMenuHtml + '</div>';
							appElm.appendChild(html);
							
							var elm = document.getElementById(app.floatSubmenu.id);
							elm.onmouseover = function() {
								clearTimeout(app.floatSubmenu.timeout);
							};
							elm.onmouseout = function() {
								app.floatSubmenu.timeout = setTimeout(() => {
									document.querySelector('#'+ app.floatSubmenu.id).remove();
								}, app.animation.speed);
							};
						} else {
							var floatSubmenu = document.querySelector('#'+ app.floatSubmenu.id);
							var floatSubmenuElm = document.querySelector('#'+ app.floatSubmenu.id + ' .'+ app.floatSubmenu.container.class);
							
							if (targetHeight > windowHeight) {
								if (floatSubmenuElm) {
									var splitClass = (app.floatSubmenu.overflow.class).split(' ');
									for (var i = 0; i < splitClass.length; i++) {
										floatSubmenuElm.classList.add(splitClass[i]);
									}
								}
							}
							floatSubmenu.setAttribute('data-offset-top', targetTop);
							floatSubmenu.setAttribute('data-menu-offset-top', targetTop);
							floatSubmenuElm.innerHTML = targetMenuHtml;
						}
				
						var targetHeight = document.querySelector('#'+ app.floatSubmenu.id).clientHeight;
						var floatSubmenuElm = document.querySelector('#'+ app.floatSubmenu.id);
						if ((windowHeight - targetTop) > targetHeight) {
							if (floatSubmenuElm) {
								floatSubmenuElm.style.top = targetTop + 'px';
								floatSubmenuElm.style.left = targetLeft + 'px';
								floatSubmenuElm.style.bottom = 'auto';
								floatSubmenuElm.style.right = targetRight + 'px';
							}
						} else {
							var arrowBottom = (windowHeight - targetTop) - 21;
							if (floatSubmenuElm) {
								floatSubmenuElm.style.top = 'auto';
								floatSubmenuElm.style.left = targetLeft + 'px';
								floatSubmenuElm.style.bottom = 0;
								floatSubmenuElm.style.right = targetRight + 'px';
							}
						}
						handleSidebarMinifyFloatMenuClick();
					} else {
						document.querySelector('#'+ app.floatSubmenu.id).remove();
						app.floatSubmenu.dom = '';
					}
				}
			}
			elm.onmouseleave = function() {
				var elm = document.querySelector('.' + app.class);
				if (elm && elm.classList.contains(app.sidebar.minify.toggledClass)) {
					app.floatSubmenu.timeout = setTimeout(() => {
						document.querySelector('#'+ app.floatSubmenu.id).remove();
						app.floatSubmenu.dom = '';
					}, 250);
				}
			}
		});
	}
};


/* 07. Handle Card - Expand
------------------------------------------------ */
var handleCardAction = function() {
	"use strict";

	if (app.card.expand.status) {
		return false;
	}
	app.card.expandStatus = true;

	// expand
	var expandTogglerList = [].slice.call(document.querySelectorAll('['+ app.card.expand.toggleAttr +']'));
	var expandTogglerTooltipList = expandTogglerList.map(function (expandTogglerEl) {
		expandTogglerEl.onclick = function(e) {
			e.preventDefault();
		
			var target = this.closest('.'+ app.card.class);
			var targetClass = app.card.expand.class;

			if (document.body.classList.contains(targetClass) && target.classList.contains(targetClass)) {
				target.removeAttribute('style');
				target.classList.remove(targetClass);
				document.body.classList.remove(targetClass);
			} else {
				document.body.classList.add(targetClass);
				target.classList.add(targetClass);
			}
		
			window.dispatchEvent(new Event('resize'));
		};
	
		return new bootstrap.Tooltip(expandTogglerEl, {
			title: app.card.expand.tooltipText,
			placement: 'bottom',
			trigger: 'hover',
			container: 'body'
		});
	});
};


/* 08. Handle Tooltip & Popover Activation
------------------------------------------------ */
var handelTooltipPopoverActivation = function() {
	"use strict";
	var tooltipTriggerList = [].slice.call(document.querySelectorAll('['+ app.tooltip.toggleAttr +']'))
	var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
		return new bootstrap.Tooltip(tooltipTriggerEl);
	});
	
	var popoverTriggerList = [].slice.call(document.querySelectorAll('['+ app.popover.toggleAttr +']'))
	var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
		return new bootstrap.Popover(popoverTriggerEl);
	});
};


/* 09. Handle Scroll to Top Button Activation
------------------------------------------------ */
var handleScrollToTopButton = function() {
	"use strict";
	var elmTriggerList = [].slice.call(document.querySelectorAll('['+ app.scrollTopButton.toggleAttr +']'));
	
	document.onscroll = function() {
		var doc = document.documentElement;
		var totalScroll = (window.pageYOffset || doc.scrollTop)  - (doc.clientTop || 0);
		var elmList = elmTriggerList.map(function(elm) {
			if (totalScroll >= 200) {
				if (!elm.classList.contains(app.scrollTopButton.showClass)) {
					elm.classList.add(app.scrollTopButton.showClass);
				}
			} else {
				elm.classList.remove(app.scrollTopButton.showClass);
			}
		});
	}
	
	var elmList = elmTriggerList.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			
			window.scrollTo({top: 0, behavior: 'smooth'});
		}
	});
};


/* 10. Handle Scroll to
------------------------------------------------ */
var handleScrollTo = function() {
	var elmTriggerList = [].slice.call(document.querySelectorAll('['+ app.scrollTo.toggleAttr +']'));
	var elmList = elmTriggerList.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
		
			var targetAttr = (elm.getAttribute(app.scrollTo.targetAttr)) ? this.getAttribute(app.scrollTo.targetAttr) : this.getAttribute('href');
			var targetElm = document.querySelectorAll(targetAttr)[0];
			var targetHeader = document.querySelectorAll('.'+ app.header.class)[0];
			var targetHeight = targetHeader.offsetHeight;
			if (targetElm) {
				var targetTop = targetElm.offsetTop - targetHeight + 36;
				window.scrollTo({top: targetTop, behavior: 'smooth'});
			}
		}
	});
};


/* 11. Handle Theme Panel Expand
------------------------------------------------ */
var handleThemePanelExpand = function() {
	var elmList = [].slice.call(document.querySelectorAll('['+ app.themePanel.toggleAttr +']'));
	
	elmList.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			
			var targetContainer = document.querySelector('.'+ app.themePanel.class);
			var targetExpand = false;
		
			if (targetContainer.classList.contains(app.themePanel.activeClass)) {
				targetContainer.classList.remove(app.themePanel.activeClass);
				setCookie(app.themePanel.expandCookie, '');
			} else {
				targetContainer.classList.add(app.themePanel.activeClass);
				setCookie(app.themePanel.expandCookie, app.themePanel.expandCookieValue);
			}
		}
	});
	
	if (getCookie(app.themePanel.expandCookie) && getCookie(app.themePanel.expandCookie) == app.themePanel.expandCookieValue) {
		var elm = document.querySelector('['+ app.themePanel.toggleAttr +']');
		if (elm) {
			elm.click();
		}
	}
};


/* 12. Handle Theme Page Control
------------------------------------------------ */
var handleThemePageControl = function() {
	// Theme Click
	var elms = [].slice.call(document.querySelectorAll('.'+ app.themePanel.themeList.class +' ['+ app.themePanel.themeList.toggleAttr +']'));
	elms.map(function(elm) {
		elm.onclick = function() {
			var targetThemeClass = this.getAttribute(app.themePanel.themeList.toggleAttr);
			for (var x = 0; x < document.body.classList.length; x++) {
				var targetClass = document.body.classList[x];
				if (targetClass.search('theme-') > -1) {
					document.body.classList.remove(targetClass);
				}
			}
			if (targetThemeClass) {
				document.body.classList.add(targetThemeClass);
			}
		
			var togglers = [].slice.call(document.querySelectorAll('.'+ app.themePanel.themeList.class +' ['+ app.themePanel.themeList.toggleAttr +']'));
			togglers.map(function(toggler) {
				if (toggler != elm) {
					toggler.closest('li').classList.remove(app.themePanel.themeList.activeClass);
				} else {
					toggler.closest('li').classList.add(app.themePanel.themeList.activeClass);
				}
			});
			handleCssVariable();
			setCookie(app.themePanel.themeList.cookieName, targetThemeClass);
			document.dispatchEvent(new CustomEvent(app.themePanel.themeList.onChangeEvent));
		}
	});
	
	// Theme Cookie
	if (getCookie(app.themePanel.themeList.cookieName) && document.querySelector('.'+ app.themePanel.themeList.class)) {
		var targetElm = document.querySelector('.'+ app.themePanel.themeList.class +' ['+ app.themePanel.themeList.toggleAttr +'="'+ getCookie(app.themePanel.themeList.cookieName) +'"]');
		if (targetElm) {
			targetElm.click();
		}
	}
	
	// Dark Mode Click
	var elms = [].slice.call(document.querySelectorAll('.'+ app.themePanel.class +' [name="'+ app.themePanel.darkMode.inputName +'"]'));
	elms.map(function(elm) {
		elm.onchange = function() {
			var targetCookie = 'light-mode';
	
			if (this.checked) {
				document.documentElement.setAttribute('data-bs-theme', 'dark');
				targetCookie = 'dark-mode';
			} else {
				document.documentElement.removeAttribute('data-bs-theme');
			}
			handleCssVariable();
			setCookie(app.themePanel.darkMode.cookieName, targetCookie);
			document.dispatchEvent(new CustomEvent(app.themePanel.themeList.onChangeEvent));
		}
	});
	
	// Dark Mode Cookie
	if (getCookie(app.themePanel.darkMode.cookieName) && document.querySelector('.'+ app.themePanel.class +' [name="'+ app.themePanel.darkMode.inputName +'"]')) {
		var elm = document.querySelector('.'+ app.themePanel.class +' [name="'+ app.themePanel.darkMode.inputName +'"]');
		if (elm) {
			elm.checked = getCookie(app.themePanel.darkMode.cookieName) === 'dark-mode';
			elm.onchange();
		}
	}
};


/* 13. Handle CSS Variable
------------------------------------------------ */
var handleCssVariable = function() {
	var rootStyle = getComputedStyle(document.body);
	
	// font
	if (app.variableFontList && app.variablePrefix) {
		for (var i = 0; i < (app.variableFontList).length; i++) {
			app.font[app.variableFontList[i].replace(/-([a-z|0-9])/g, (match, letter) => letter.toUpperCase())] = rootStyle.getPropertyValue('--'+ app.variablePrefix + app.variableFontList[i]).trim();
		}
	}
	
	// color
	if (app.variableColorList && app.variablePrefix) {
		for (var i = 0; i < (app.variableColorList).length; i++) {
			app.color[app.variableColorList[i].replace(/-([a-z|0-9])/g, (match, letter) => letter.toUpperCase())] = rootStyle.getPropertyValue('--'+ app.variablePrefix + app.variableColorList[i]).trim();
		}
	}
};


/* 14. Handle Toggle Class
------------------------------------------------ */
var handleToggleClass = function() {
	var elmList = [].slice.call(document.querySelectorAll('['+ app.toggleClass.toggleAttr +']'));
	
	elmList.map(function(elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			
			var targetToggleClass = this.getAttribute(app.toggleClass.toggleAttr);
			var targetDismissClass = this.getAttribute(app.dismissClass.toggleAttr);
			var targetToggleElm = document.querySelector(this.getAttribute(app.toggleClass.targetAttr));
		
			if (!targetDismissClass) {
				if (targetToggleElm.classList.contains(targetToggleClass)) {
					targetToggleElm.classList.remove(targetToggleClass);
				} else {
					targetToggleElm.classList.add(targetToggleClass);
				}
			} else {
				if (!targetToggleElm.classList.contains(targetToggleClass) && !targetToggleElm.classList.contains(targetDismissClass)) {
					if (targetToggleElm.classList.contains(targetToggleClass)) {
						targetToggleElm.classList.remove(targetToggleClass);
					} else {
						targetToggleElm.classList.add(targetToggleClass);
					}
				} else {
					if (targetToggleElm.classList.contains(targetToggleClass)) {
						targetToggleElm.classList.remove(targetToggleClass);
					} else {
						targetToggleElm.classList.add(targetToggleClass);
					}
					if (targetToggleElm.classList.contains(targetDismissClass)) {
						targetToggleElm.classList.remove(targetDismissClass);
					} else {
						targetToggleElm.classList.add(targetDismissClass);
					}
				}
			}
		}
	});
}


/* 15. Handle Top Menu - Unlimited Nav Render
------------------------------------------------ */
var handleUnlimitedTopNavRender = function() {
	"use strict";
	// function handle menu button action - next / prev
	function handleMenuButtonAction(element, direction) {
		var obj = element.closest('.' + app.topNav.menu.class);
		var objStyle = window.getComputedStyle(obj);
		var bodyStyle = window.getComputedStyle(document.querySelector('body'));
		var targetCss = (bodyStyle.getPropertyValue('direction') == 'rtl') ? 'margin-right' : 'margin-left';
		var marginLeft = parseInt(objStyle.getPropertyValue(targetCss));  
		var containerWidth = document.querySelector('.'+ app.topNav.class).clientWidth - document.querySelector('.'+ app.topNav.class).clientHeight * 2;
		var totalWidth = 0;
		var finalScrollWidth = 0;
		var controlPrevObj = obj.querySelector('.menu-control-start');
		var controlPrevWidth = (controlPrevObj) ? controlPrevObj.clientWidth : 0;
		var controlNextObj = obj.querySelector('.menu-control-end');
		var controlNextWidth = (controlPrevObj) ? controlNextObj.clientWidth : 0;
		var controlWidth = controlPrevWidth + controlNextWidth;
		
		var elms = [].slice.call(obj.querySelectorAll('.' + app.topNav.menu.itemClass));
		if (elms) {
			elms.map(function(elm) {
				if (!elm.classList.contains(app.topNav.control.class)) {
					totalWidth += elm.clientWidth;
				}
			});
		}

		switch (direction) {
			case 'next':
				var widthLeft = totalWidth + marginLeft - containerWidth;
				if (widthLeft <= containerWidth) {
					finalScrollWidth = widthLeft - marginLeft - controlWidth;
					setTimeout(function() {
						obj.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.remove('show');
					}, app.animation.speed);
				} else {
					finalScrollWidth = containerWidth - marginLeft - controlWidth;
				}

				if (finalScrollWidth !== 0) {
					obj.style.transitionProperty = 'height, margin, padding';
					obj.style.transitionDuration = app.animation.speed + 'ms';
					if (bodyStyle.getPropertyValue('direction') != 'rtl') {
						obj.style.marginLeft = '-' + finalScrollWidth + 'px';
					} else {
						obj.style.marginRight = '-' + finalScrollWidth + 'px';
					}
					setTimeout(function() {
						obj.style.transitionProperty = '';
						obj.style.transitionDuration = '';
						obj.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.add('show');
					}, app.animation.speed);
				}
				break;
			case 'prev':
				var widthLeft = -marginLeft;

				if (widthLeft <= containerWidth) {
					obj.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.remove('show');
					finalScrollWidth = 0;
				} else {
					finalScrollWidth = widthLeft - containerWidth + controlWidth;
				}
				
				obj.style.transitionProperty = 'height, margin, padding';
				obj.style.transitionDuration = app.animation.speed + 'ms';
				
				if (bodyStyle.getPropertyValue('direction') != 'rtl') {
					obj.style.marginLeft = '-' + finalScrollWidth + 'px';
				} else {
					obj.style.marginRight = '-' + finalScrollWidth + 'px';
				}
				
				setTimeout(function() {
					obj.style.transitionProperty = '';
					obj.style.transitionDuration = '';
					obj.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.add('show');
				}, app.animation.speed);
				break;
		}
	}

	// handle page load active menu focus
	function handlePageLoadMenuFocus() {
		var targetMenu = document.querySelector('.'+ app.topNav.class +' .'+ app.topNav.menu.class);
		if (!targetMenu) {
			return;
		}
		var targetMenuStyle = window.getComputedStyle(targetMenu);
		var bodyStyle = window.getComputedStyle(document.body);
		var targetCss = (bodyStyle.getPropertyValue('direction') == 'rtl') ? 'margin-right' : 'margin-left';
		var marginLeft = parseInt(targetMenuStyle.getPropertyValue(targetCss));
		var viewWidth = document.querySelector('.'+ app.topNav.class +'').clientWidth;
		var prevWidth = 0;
		var speed = 0;
		var fullWidth = 0;
		var controlPrevObj = targetMenu.querySelector('.menu-control-start');
		var controlPrevWidth = (controlPrevObj) ? controlPrevObj.clientWidth : 0;
		var controlNextObj = targetMenu.querySelector('.menu-control-end');
		var controlNextWidth = (controlPrevObj) ? controlNextObj.clientWidth : 0;
		var controlWidth = 0;

		var elms = [].slice.call(document.querySelectorAll('.'+ app.topNav.class +' .'+ app.topNav.menu.class + ' > .'+ app.topNav.menu.itemClass +''));
		if (elms) {
			var found = false;
			elms.map(function(elm) {
				if (!elm.classList.contains('menu-control')) {
					fullWidth += elm.clientWidth;
					if (!found) {
						prevWidth += elm.clientWidth;
					}
					if (elm.classList.contains('active')) {
						found = true;
					}
				}
			});
		}
		
		var elm = targetMenu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class);
		if (prevWidth != fullWidth && fullWidth >= viewWidth) {
			elm.classList.add(app.topNav.control.showClass);
			controlWidth += controlNextWidth;
		} else {
			elm.classList.remove(app.topNav.control.showClass);
		}

		var elm = targetMenu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class);
		if (prevWidth >= viewWidth && fullWidth >= viewWidth) {
			elm.classList.add(app.topNav.control.showClass);
		} else {
			elm.classList.remove(app.topNav.control.showClass);
		}
		
		if (prevWidth >= viewWidth) {
			var finalScrollWidth = prevWidth - viewWidth + controlWidth;
			if (bodyStyle.getPropertyValue('direction') != 'rtl') {
				targetMenu.style.marginLeft = '-' + finalScrollWidth + 'px';
			} else {
				targetMenu.style.marginRight = '-' + finalScrollWidth + 'px';
			}
		}
	}

	// handle menu next button click action
	var elm = document.querySelector('['+ app.topNav.control.buttonNext.toggleAttr +']');
	if (elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			handleMenuButtonAction(this,'next');
		};
	}
	
	// handle menu prev button click action
	var elm = document.querySelector('['+ app.topNav.control.buttonPrev.toggleAttr +']');
	if (elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			handleMenuButtonAction(this,'prev');
		};
	}

	function enableFluidContainerDrag(containerClassName) {
		const container = document.querySelector(containerClassName);
		if (!container) {
			return;
		}
		const menu = container.querySelector('.menu');
		const menuItem = menu.querySelectorAll('.menu-item:not(.menu-control)');

		let startX, scrollLeft, mouseDown;
		let menuWidth = 0;
		let maxScroll = 0;

		menuItem.forEach((element) => {
			menuWidth += element.offsetWidth;
		});

		container.addEventListener('mousedown', (e) => {
			mouseDown = true;
			startX = e.pageX;
			scrollLeft = (menu.style.marginLeft) ? parseInt(menu.style.marginLeft) : 0;
			maxScroll = container.offsetWidth - menuWidth;
		});

		container.addEventListener('touchstart', (e) => {
			mouseDown = true;
			const touch = e.targetTouches[0];
			startX = touch.pageX;
			scrollLeft = (menu.style.marginLeft) ? parseInt(menu.style.marginLeft) : 0;
			maxScroll = container.offsetWidth - menuWidth;
		});
		
		container.addEventListener('mouseup', () => {
			mouseDown = false;
		});

		container.addEventListener('touchend', () => {
			mouseDown = false;
		});
		
		container.addEventListener('mousemove', (e) => {
			if (!startX || !mouseDown) return;
			if (window.innerWidth < 992) return;
			e.preventDefault();
			const x = e.pageX;
			const walkX = (x - startX) * 1;
			var totalMarginLeft = scrollLeft + walkX;
			if (totalMarginLeft <= maxScroll) {
				totalMarginLeft = maxScroll;
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.remove('show');
			} else {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.add('show');
			}
			if (menuWidth < container.offsetWidth) {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.remove('show');
			}
			if (maxScroll > 0) {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.remove('show');
			}
			if (totalMarginLeft > 0) {
				totalMarginLeft = 0;
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.remove('show');
			} else {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.add('show');
			}
			menu.style.marginLeft = totalMarginLeft + 'px';
		});
		
		container.addEventListener('touchmove', (e) => {
			if (!startX || !mouseDown) return;
			if (window.innerWidth < 992) return;
			e.preventDefault();
			const touch = e.targetTouches[0];
			const x = touch.pageX;
			const walkX = (x - startX) * 1;
			var totalMarginLeft = scrollLeft + walkX;
			if (totalMarginLeft <= maxScroll) {
				totalMarginLeft = maxScroll;
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.remove('show');
			} else {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.add('show');
			}
			if (menuWidth < container.offsetWidth) {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.remove('show');
			}
			if (maxScroll > 0) {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonNext.class).classList.remove('show');
			}
			if (totalMarginLeft > 0) {
				totalMarginLeft = 0;
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.remove('show');
			} else {
				menu.querySelector('.'+ app.topNav.control.class +'.'+ app.topNav.control.buttonPrev.class).classList.add('show');
			}
			menu.style.marginLeft = totalMarginLeft + 'px';
		});
	}
	
	
	
	window.addEventListener('resize', function() {
		if (window.innerWidth >= 992) {
			var targetElm = document.querySelector('.'+ app.topNav.class);
			if (targetElm) {
				targetElm.removeAttribute('style');
			}
			var targetElm2 = document.querySelector('.'+ app.topNav.class +' .'+ app.topNav.menu.class);
			if (targetElm2) {
				targetElm2.removeAttribute('style');
			}
			var targetElm3 = document.querySelectorAll('.'+ app.topNav.class +' .'+ app.topNav.menu.submenu.class);
			if (targetElm3) {
				targetElm3.forEach((elm3) => {
					elm3.removeAttribute('style');
				});
			}
			handlePageLoadMenuFocus();
		}
		enableFluidContainerDrag('.'+ app.topNav.class);
	});
	
	
	if (window.innerWidth >= 992) {
		handlePageLoadMenuFocus();
		enableFluidContainerDrag('.'+ app.topNav.class);
	}
};


/* 16. Handle Top Nav - Submenu Toggle
------------------------------------------------ */
var handleTopNavToggle = function(menus, forMobile = false) {
	menus.map(function(menu) {
		menu.onclick = function(e) {
			e.preventDefault();
			
			if (!forMobile || (forMobile && document.body.clientWidth < 992)) {
				var target = this.nextElementSibling;
				menus.map(function(m) {
					var otherTarget = m.nextElementSibling;
					if (otherTarget !== target) {
						slideUp(otherTarget);
						otherTarget.closest('.'+ app.topNav.menu.itemClass).classList.remove(app.topNav.menu.expandClass);
						otherTarget.closest('.'+ app.topNav.menu.itemClass).classList.add(app.topNav.menu.closedClass);
					}
				});
			
				slideToggle(target);
			}
		}
	});
};
var handleTopNavSubMenu = function() {
	"use strict";
	
	var menuBaseSelector = '.'+ app.topNav.class +' .'+ app.topNav.menu.class +' > .'+ app.topNav.menu.itemClass +'.'+ app.topNav.menu.hasSubClass;
	var submenuBaseSelector = ' > .'+ app.topNav.menu.submenu.class +' > .'+ app.topNav.menu.itemClass + '.' + app.topNav.menu.hasSubClass;
	
	// 14.1 Menu - Toggle / Collapse
	var menuLinkSelector =  menuBaseSelector + ' > .'+ app.topNav.menu.itemLinkClass;
	var menus = [].slice.call(document.querySelectorAll(menuLinkSelector));
	handleTopNavToggle(menus, true);
	
	// 14.2 Menu - Submenu lvl 1
	var submenuLvl1Selector = menuBaseSelector + submenuBaseSelector;
	var submenusLvl1 = [].slice.call(document.querySelectorAll(submenuLvl1Selector + ' > .' + app.topNav.menu.itemLinkClass));
	handleTopNavToggle(submenusLvl1);
	
	// 14.3 submenu lvl 2
	var submenuLvl2Selector = menuBaseSelector + submenuBaseSelector + submenuBaseSelector;
	var submenusLvl2 = [].slice.call(document.querySelectorAll(submenuLvl2Selector + ' > .' + app.topNav.menu.itemLinkClass));
	handleTopNavToggle(submenusLvl2);
};


/* 17. Handle Top Nav - Mobile Toggle
------------------------------------------------ */
var handleTopNavMobileToggle = function() {
	"use strict";
	
	var elm = document.querySelector('['+ app.topNav.mobile.toggleAttr +']');
	if (elm) {
		elm.onclick = function(e) {
			e.preventDefault();
			slideToggle(document.querySelector('.'+ app.topNav.class));
			window.scrollTo(0,0);
		}
	}
};


/* Application Controller
------------------------------------------------ */
var App = function () {
	"use strict";
	
	return {
		//main function
		init: function () {
			this.initComponent();
			this.initSidebar();
			this.initTopNav();
		},
		initSidebar: function() {
			handleSidebarScrollMemory();
			handleSidebarMinifyFloatMenu();
			handleSidebarMenu();
			handleSidebarMinify();
			handleSidebarMobileToggle();
			handleSidebarMobileDismiss();
		},
		initTopNav: function() {
			handleUnlimitedTopNavRender();
			handleTopNavSubMenu();
			handleTopNavMobileToggle();
		},
		initComponent: function() {
			handleScrollbar();
			handleCardAction();
			handelTooltipPopoverActivation();
			handleScrollToTopButton();
			handleScrollTo();
			handleThemePanelExpand();
			handleThemePageControl();
			handleCssVariable();
			handleToggleClass();
		},
		scrollTop: function() {
			window.scrollTo({top: 0, behavior: 'smooth'});
		}
	};
}();

document.addEventListener('DOMContentLoaded', function() {
	App.init();
});