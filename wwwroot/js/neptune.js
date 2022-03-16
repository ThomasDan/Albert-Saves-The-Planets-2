var $el1;
var $el2;
var $el3;
var $el4;
var $el5;


setTimeout(function() {
    $el1 = $('.magic:not(.active');
    $el1.addClass('active');
}, 2000);

setTimeout(function() {
    $el2 = $('.dialogtxttwo:not(.active');
    $el2.addClass('active');
}, 2500);

setTimeout(function() {
    $el3 = $('.magictwo:not(.active');
    $el3.addClass('active');
}, 4000);

setTimeout(function() {
    $el4 = $('.dialogtxt:not(.active');
    $el4.addClass('active');
}, 4500);

setTimeout(function() {
    $el5 = $('.dialogtxtthre:not(.active');
    $el5.addClass('active');
}, 6000);

setTimeout(function() {
    $el5 = $('.facts:not(.active');
    $el5.addClass('active');
}, 8000);

console.log('Javascript is working');