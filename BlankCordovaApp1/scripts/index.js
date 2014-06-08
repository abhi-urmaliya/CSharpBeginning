// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in Ripple or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        // TODO: Cordova has been loaded. Perform any initialization that requires Cordova here.

        // DATABASE IMPLEMENTATION ATTEMPT
        //var db = window.openDatabase("Database", "1.0", "GemStore", 2000000);
        //db.transaction(populateDB, errorCB, successCB);
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };

    var storage = window.localStorage;
    window.localStorage.setItem("Charul", "9597368193");
    window.localStorage.setItem("Dilip", "8883141089");
    window.localStorage.setItem("Farhan", "8939004687");
    window.localStorage.setItem("Nitish", "9731842165");
    window.localStorage.setItem("Parth", "8148748753");
    window.localStorage.setItem("Sathya", "9629323672");
    window.localStorage.setItem("Shreyas", "9810063298");
    window.localStorage.setItem("Tushar", "9626397545");
    //function populateDB(tx) {
    //    tx.executeSql('CREATE TABLE IF NOT EXISTS GEM (id unique, data)');
    //    tx.executeSql('INSERT INTO GEM (id, data) VALUES ("Azurite", "price: 2.95, canPurchase: true, soldOut: false")');
    //}

    //function queryDB(tx) {
    //    tx.executeSql('SELECT * FROM GEM', [], querySuccess, errorCB);
    //}

    // Query the success callback
    //
    //function querySuccess(tx, results) {
    //    var len = results.rows.length;
    //    alert("GEM table: " + len + " rows found.");
    //    for (var i = 0; i < len; i++) {
    //        alert("Row = " + i + " ID = " + results.rows.item(i).id + " Data =  " + results.rows.item(i).data);
    //    }
    //}

    //function errorCB(tx, err) {
    //    alert("Error processing SQL:" + err);
    //}

    //function successCB(tx, err) {
    //    var db = window.openDatabase("Database", "1.0", "GemStore", 200000);
    //    db.transaction(queryDB, errorCB);
    //}

    var telephone;
    
    var app = angular.module('phoneBook', []);
    alert("hello");
    app.controller('callBook', function () {
        this.display = display;
        this.tel = telephone;
    });
    function display() {
        alert("hello");
        telephone = window.localStorage.getItem(document.getElementById('fn').value);
    }
} )();