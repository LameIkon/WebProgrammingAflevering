const TITLE = document.getElementById('title');
const PICTURE = document.getElementById('picture');
const DISCRIPTION = document.getElementById('discription');

const ERROR_MESSAGE = 'error-message';

const ALLOWED_FORMATS = ['png', 'jpg'];

function addErrorMessage(element) {
    return (`${element.id}-${ERROR_MESSAGE}`);
};

if (TITLE != null) {
    TITLE.addEventListener('change', function () {

        const ERROR = document.getElementById(addErrorMessage(TITLE));
        const MESSAGE = TITLE.value;

        function write(message) {
            ERROR.innerText = message;
        }

        if (!MESSAGE.match(/.+/)) {
            write('Your post must have a title');
        }
        else if (!MESSAGE.match(/\S{6,50}/)) {
            write('Your title must be longer than 6 and no more than 50 characters');
        }
        else {
            write('');
        }
    })
}

if (PICTURE != null) {
    PICTURE.addEventListener('change', function () {

        const ERROR = document.getElementById(addErrorMessage(PICTURE));
        const FILE_PARTS = PICTURE.value.split('.');
        console.log(FILE_PARTS);
        const FORMAT = FILE_PARTS[FILE_PARTS.length - 1];


        function write(message) {
            ERROR.innerText = message;
        }


        if (FILE_PARTS.length > 2) {
            write('Format not allowed (Only .jpg and .png)')
        }
        else {
            if (!FORMAT.match(/(.jpg|.png)/)) {
                write('Format not allowed (Only .jpg and .png)');
            }
            else {
                write('');
            }
        }
    })
}