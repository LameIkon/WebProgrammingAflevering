


function ajaxCall()
{
    let AJAX = new XMLHttpRequest();

    AJAX.open('GET', 'ajax', true);


    AJAX.onload = () =>
    {
        if (AJAX.status == 200)
        {
            let website = (this.respose);

            console.log(website);

        }
    }

    AJAX.send();

}
