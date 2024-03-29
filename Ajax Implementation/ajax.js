console.log("Ajax Implementation...........");


let fetchBtn = document.getElementById('fetchBtn');
fetchBtn.addEventListener('click', buttonClickHandler)

function buttonClickHandler(event) 
{
    event.preventDefault();
     console.log('You have clicked the fetchBtn');

   setTimeout(function(){ // Instantiate an xhr object
    const xhr = new XMLHttpRequest();

    // Open the object
    // xhr.open('GET', 'https://jsonplaceholder.typicode.com/todos/1',true);

    // USE THIS FOR POST REQUEST
    xhr.open('POST', 'https://dummy.restapiexample.com/api/v1/create', true);
    xhr.getResponseHeader('Content-type', 'application/json');


    // What to do on progress (optional)
    xhr.onprogress = function(){
        console.log('On progress');
    }


//---------this for the ready state ------- 
    // xhr.onreadystatechange = function () {
    //     console.log('ready state is ', xhr.readyState);
        
    // }



    // What to do when response is ready
    xhr.onload = function () {
        if(this.status === 200){

            console.log(this.responseText)
        }
        else{
            console.log("Some error occured")
        }
    }

    // send the request
    params = `{"name":"test12","salary":"123","age":"23"}`;
    xhr.send(params);

    console.log("We are done!");
},2000);

}
//--------------------------Populate Button--------------------------

let popBtn = document.getElementById('popBtn');
popBtn.addEventListener('click', popHandler);

function popHandler(event) {
    event.preventDefault()
    console.log('You have clicked the pop handler');

    setTimeout(function() {// Instantiate an xhr object
    const xmlXHR = new XMLHttpRequest();

    // Open the object
    xmlXHR.open('GET', 'https://dummy.restapiexample.com/api/v1/employees', true);


    // What to do when response is ready
    xmlXHR.onload = function () {
        if(this.status === 200){
            let obj = JSON.parse(this.responseText);
            console.log(obj);
            //-------------error
            let list = document.getElementById('list');
            str = "";
            for (key in obj.data)
            {
                str += `<li>${obj.data[key].employee_name} </li>`;
            }
            list.innerHTML = str;
        }
        else{
            console.log("Some error occured")
        }
    }

    // send the request
    xmlXHR.send();
    console.log("We are done fetching employees!");
}, 2000);
    
}

