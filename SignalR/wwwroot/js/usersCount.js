// start a connection

var connection = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

// when the connection is started, call the server method

connection.on("updateTotalViews", (value) =>
{
    var newcount = document.getElementById("totalViewsCounter");
    newcount.innerText = value.toString();
})

connection.on("updateTotalUsers", (value) => {
    var newcount = document.getElementById("totalUsersCounter");
    newcount.innerText = value.toString();
})

// invoke the server methods to get the current value on page load  

function newWindowLoadedOnClient()
{
    connection.send("NewWindowLoaded")/*, "Suyog").then((value) => console.log(value));*/
    // suyog is the user name which is passed to the server method
    // and then we are printing the value returned from the server method using console.log 
    // difference between invoke and send is that invoke is used to get the return value from the server method 
}

// start the connection

connection.start().then(function ()
{
    console.log("connection is successfull");
    newWindowLoadedOnClient();
}).catch(function (err)
{
    return console.error(err.toString());
});// JavaScript source code 