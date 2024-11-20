const TITLE = document.getElementById('email');
const PICTURE = document.getElementById('username');
const DISCRIPTION = document.getElementById('password');

const ERROR_MESSAGE = 'error-message';

function addErrorMessage(element) {
    return (`${element.id}-${ERROR_MESSAGE}`);
};

TITLE.addEventListener('change', function () {

    const ERROR = document.getElementById(addErrorMessage(TITLE));
    const MESSAGE = TITLE.value;

    function write(message) {
        ERROR.innerText = message;
    }

    if (!MESSAGE.match(/.+/)) {
        write('Your post must have a title');
    }
    else if (!MESSAGE.match(/\w{6, 50}/)) {
        write('Your username must be longer than 6 and no more than 50 characters');
    }
    else {
        write('');
    }
})

