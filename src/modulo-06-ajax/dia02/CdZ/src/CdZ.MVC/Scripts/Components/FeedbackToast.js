'use strict';

function FeedbackToast(options) {
    options = options || {};
    this.element = options.element;
    this.title = options.title;
    this.element.find('.title').text = this.title;
    this.element.find('.close').click(function () {
        $(this).closest('.feedback-toast').fadeOut();
    });
};

FeedbackToast.prototype.show = function (msg) {
    this.element.find('.msg').text(msg);
    this.element.show();
};