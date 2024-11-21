const EMAIL = document.getElementById('email');
const USERNAME = document.getElementById('username');
const PASSWORD = document.getElementById('password');
const REPEAT_PASSWORD = document.getElementById('repeat-password');
const REGISTER = document.getElementById('register');

const ERROR_MESSAGE = 'error-message';

if (REGISTER != null) {
    REGISTER.disabled = true;
}

let registerBooleans = [false, false, false, false]


function addErrorMessage(element)
{
    return (`${element.id}-${ERROR_MESSAGE}`);
};
   
if (USERNAME != null) {
    USERNAME.addEventListener('change', function () {

        registerBooleans[0] = false;
        turnRegisterButtonOn();

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
            registerBooleans[0] = true;
            turnRegisterButtonOn();
        }
    })
}

if (EMAIL != null) {
    EMAIL.addEventListener('change', function () {

        registerBooleans[1] = false;
        turnRegisterButtonOn();
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
            registerBooleans[1] = true;
            turnRegisterButtonOn();
        }
    })
}

if (PASSWORD != null) {
    PASSWORD.addEventListener('change', function () {

        registerBooleans[2] = false;
        turnRegisterButtonOn();

        const ERROR = document.getElementById(addErrorMessage(PASSWORD));
        const MESSAGE = PASSWORD.value;

        function write(message) {
            ERROR.innerText = message;
        }


        if (!MESSAGE.match(/\S{8,30}/)) {
            write('Your password must be between 8 and 30 characters');
        }
        else if (!MESSAGE.match(/[A-Z]+/)) {
            write('Your password must contain at least one capital letter');
        }
        else if (!MESSAGE.match(/[1-9]+/)) {
            write('Your password must contain at least one number');
        }
        else {
            write('');
            registerBooleans[2] = true;
            turnRegisterButtonOn();
        }
    })
}

if (REPEAT_PASSWORD != null) {
    REPEAT_PASSWORD.addEventListener('change', function () {

        registerBooleans[3] = false;
        turnRegisterButtonOn();

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
            registerBooleans[3] = true;
            turnRegisterButtonOn();
        }
    })
}

function turnRegisterButtonOn() {
    if (REGISTER != null) {
        for (let i = 0; i < registerBooleans.length; i++) {
            REGISTER.disabled = true;

            if (registerBooleans[i] == false) break;

            REGISTER.disabled = false;

        }
    }
}