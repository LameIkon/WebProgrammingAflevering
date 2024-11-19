const EMAIL = document.getElementById('email');
const USERNAME = document.getElementById('username');
const PASSWORD = document.getElementById('password');
const REPEAT_PASSWORD = document.getElementById('repeat-password');

const ERROR_MESSAGE = 'error-message';

const REGEX_NAME = /([A - Z])\w+/;

function addErrorMessage(element)
{
    return (`${element.id}-${ERROR_MESSAGE}`);
};
    

function addErrorMessageListener(element)
{
    if (element != null) {
        element.addEventListener('change', function () {

            const ERROR = document.getElementById(addErrorMessage(element));
            ERROR.innerText = element.value;
        })
    }
}


addErrorMessageListener(EMAIL);
addErrorMessageListener(USERNAME) ;
addErrorMessageListener(PASSWORD);
addErrorMessageListener(REPEAT_PASSWORD);