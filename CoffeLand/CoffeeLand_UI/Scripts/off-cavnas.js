! function($) {
    "use strict";
    $(document).ready(function() {
        var $btn = $('.btn-navbar'),
            $nav = null,
            $logo = '',
            $fixeditems = null;
        if (!$btn.length) {
            return;
        }
        $nav = $('<div class="noo-main-canvas"></div>').appendTo($('<div id="off-canvas-nav"><div class="off-canvas-header"><span class="remove-menumobile icon_close"></span></div></div>').appendTo(document.body));
        $($btn.data('target')).clone().appendTo($nav);
        $('.custom-logo-link img').clone().appendTo('.off-canvas-header');
        $('.noo_icon_menu').click(function() {
            if ($('body').hasClass('noo-open-canvas')) {
                hideMenu();
            } else {
                showMenu();
            }
        });

        function showMenu() {
            $('body').addClass('noo-open-canvas');
            setTimeout(function() {
                $('body').addClass('noo-canvas-enabled');
                $('#off-canvas-nav').bind('click', function(e) {
                    e.stopPropagation();
                });
                $('html').bind('click', bdHideNav);
                $('.remove-menumobile').bind('click', bdHideNav);
            }, 50);
        }

        function bdHideNav(e) {
            e.preventDefault();
            hideMenu();
            return false;
        }

        function hideMenu() {
            $('#off-canvas-nav').unbind('click');
            $('html').unbind('click', bdHideNav);
            $('body').removeClass('noo-canvas-enabled');
            setTimeout(function() {
                $('body').removeClass('noo-open-canvas');
            }, 600);
        }
        $('<i class="fa fa-caret-down noo-sub-icon"></i>').appendTo('.noo-main-canvas ul .menu-item-has-children');
        $('.noo-sub-icon').click(function() {
            var $this = $(this);
            var $sub_menu = $this.prev();
            var $parent = $this.parent().parent();
            if ($sub_menu.hasClass('show-sub')) {
                $this.removeClass('fa-caret-up').addClass('fa-caret-down');
                $sub_menu.removeClass('show-sub').slideUp(200);
            } else {
                if (!$parent.hasClass('sub-menu')) {
                    $('.show-sub').next().removeClass('fa-caret-up').addClass('fa-caret-down');
                    $('.show-sub').removeClass('show-sub').slideUp(200);
                }
                $this.removeClass('fa-caret-down').addClass('fa-caret-up');
                $sub_menu.addClass('show-sub').slideDown(200);
            }
        });
    })
}(jQuery);
