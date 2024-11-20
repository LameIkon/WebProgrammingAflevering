const EMAIL = document.getElementById('email');
const USERNAME = document.getElementById('username');
const PASSWORD = document.getElementById('password');
const REPEAT_PASSWORD = document.getElementById('repeat-password');
const REGISTER = document.getElementById('register');

const ERROR_MESSAGE = 'error-message';

function addErrorMessage(element)
{
    return (`${element.id}-${ERROR_MESSAGE}`);
};
   
if (USERNAME != null) {
    USERNAME.addEventListener('change', function () {

        const ERROR = document.getElementById(addErrorMessage(USERNAME));
        const MESSAGE = USERNAME.value;

        function write(message) {
            ERROR.innerText = message;
        }

        if (!MESSAGE.match(/[A-Z]\w+/)) {
            write('Your name must begin with a captial letter');
        }
        else if (!MESSAGE.match(/\w{4,20}/)) {
            write('Your username must be longer than 4 and under 20 characters');
        }
        else {
            write('');
        }
    })
}

if (EMAIL != null) {
    EMAIL.addEventListener('change', function () {

        const ERROR = document.getElementById(addErrorMessage(EMAIL));
        const MESSAGE = EMAIL.value;

        function write(message) {
            ERROR.innerText = message;
        }

        if (!MESSAGE.match(/[a-z1-9]+@[a-z1-9]+\.{1}[a-z]+\.?[a-z]+/)) {
            write('Please enter a valid email');
        }
        else {
            write('');
        }
    })
}

if (PASSWORD != null) {
    PASSWORD.addEventListener('change', function () {

        const ERROR = document.getElementById(addErrorMessage(PASSWORD));
        const MESSAGE = PASSWORD.value;

        function write(message) {
            ERROR.innerText = message;
        }


        if (!MESSAGE.match(/\S{8,30}/)) {
            write('Your password must be between 8 and 30 characters');
        }
        else if (!MESSAGE.match(/[A-Z]+/)) {
            write('Your password must contain at leaste one capital letter');
        }
        else if (!MESSAGE.match(/[1-9]+/)) {
            write('Your password must contain at leaste one number');
        }
        else {
            write('');
        }
    })
}

if (REPEAT_PASSWORD != null) {
    REPEAT_PASSWORD.addEventListener('change', function () {

        const ERROR = document.getElementById(addErrorMessage(REPEAT_PASSWORD));
        const MESSAGE = REPEAT_PASSWORD.value;

        function write(message) {
            ERROR.innerText = message;
        }


        if (!MESSAGE.match(PASSWORD.value)) {
            write('Passwords do not match');
        }
        else {
            write('');
        }
    })
}

