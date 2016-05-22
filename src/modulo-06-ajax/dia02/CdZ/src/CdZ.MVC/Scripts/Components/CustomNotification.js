'use strict';

function CustomNotification(options) {
    options = options || {};
    this.icon = options.icon || 'https://cloud.githubusercontent.com/assets/526075/15454731/55acd266-2017-11e6-8423-87b8878caefa.png';
};

CustomNotification.prototype.send = function (msg) {
    Notification.requestPermission().then(function (result) {
        if (result === 'granted') {
            var options = {
                body: msg,
                icon: this.icon
            }
            new Notification('', options);
        }
    }.bind(this));
};