const EMAIL = document.getElementById('email');
const USERNAME = document.getElementById('username');
const PASSWORD = document.getElementById('password');
const REPEAT_PASSWORD = document.getElementById('repeat-password');



function addErrorMessage(element)
{
    const ERROR_MESSAGE = 'error-message';

    return (`${element.id}-${ERROR_MESSAGE}`);
};


EMAIL.addEventListener('change', function (event)
{
    const MESSAGE = addErrorMessage(EMAIL);

    const ERROR = document.getElementById(MESSAGE);
    ERROR.innerText = EMAIL.value;
});
    

function newMessage() { }