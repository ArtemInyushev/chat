/* eslint-disable no-undef */

class Toast{
    static async ShowToastMessage(title, body, titleClass) {
        let toastEl = $(".toast.hide").last();
        if (!toastEl.length) {
            toastEl = $(".toast").last();
        }
        $('.toast-container').prepend(toastEl);
        await this.#UpdateToastMessage(toastEl, title, body, titleClass);
        toastEl.toast({ delay: 10000 });
        toastEl.toast("show");
    }
    
    static async #UpdateToastMessage(toast, title, body, titleClass) {
        const titleEl = toast.find("strong");
        titleEl.text(title);
        if (titleClass) {
            if (!titleEl.hasClass(titleClass)) {
                titleEl.removeClass(function (index, className) {
                    return (className.match(/(^|\s)text-\S+/g) || []).join(' ');
                });
                titleEl.addClass(titleClass);
            }        
        }
        toast.find(".toast-body").text(body);
    }
}

export default Toast;