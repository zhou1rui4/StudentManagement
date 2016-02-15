    'use strict';

    app.directive('fmDate', function () {
        return {
                restrict: 'A',
                require: 'ngModel',
                priority: 1, // needed for angular 1.2.x
                link: function (scope, elm, attr, selectCtrl) {
                    var format = attr.fmDate || 'mm/dd/yyyy';
                    if (attr.type === 'radio' || attr.type === 'checkbox'||attr.type === 'button' ) return;

                    $(elm).datepicker({
                        autoclose: true,
                        format: format
                    });
                    
                    $(elm).val(new Date()).datepicker('update');
                    
                    $(elm).bind('change', function () {
                        scope.$apply(function () {
                            selectCtrl.$setViewValue(elm.val());
                        });
                    });
                }
             };
    });
