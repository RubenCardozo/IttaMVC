"use strict";
var nom = '"pie\'rre"' + ' eric';
var i = 15;
var j = "20";
var z = parseInt("12 lapins");
var u = parseFloat("12.6");
console.log(nom);
console.log(i + j);
console.log(z);

function f1(f, g, h) {
    if (typeof (f) == 'number') { //string, objet, function, boolean
        f += 1;
    }

    if (h == undefined) h = window.h;

    g = typeof (g) == undefined ? "" : g;

    console.log(f + g + h);
}

f1(14, 45, 10);
f1("12", 45, 10);
f1("hello ", " wordl ");

var t = new Array();
var t1 = [];
console.log(t instanceof Array);
console.log(t1 instanceof Array);
console.log(Object.prototype);

//*******************************************************
//Creation de un Objet sans type ou sans prototype
//*******************************************************

separateur();
var o1 = {
    nom: "Jean",
    age: 18,
    affiche: function () {
        console.log(this.toString());
    },
    toString: function () {
        return (this.nom + ' a ' + this.age + ' ans.');
    }
};

console.log(o1.nom);
o1.affiche();
console.log(o1.toString());
o1.prenom = "Paul";

o1.toString = function () {
    return this.nom + " " + this.prenom + " a " + this.age + " ans."
};
o1.affiche();

var o2 = o1;
o1.prenom = "John";
o2.affiche();


function separateur() {
    console.log("************************************");
};
separateur();

//************************************************
//Creation de un type Chien
//************************************************

var Chien = function (nom = "RTP"){ 
    this.setNom(nom);
};

Chien.prototype.setNom = function (nom) {
    this.nom = nom;
};
Chien.prototype.getNom = function () {
    return this.nom;
};

var milou = new Chien();
milou.setNom("milou");
console.log(milou.getNom());
console.log(milou.constructor.name);

//milou.nom = "Milou"; //interdit
//console.log(milou.nom)

separateur();

var bill = new Chien("Bill"); 
console.log(bill.getNom());

//************************************************
//Heritage
//************************************************
separateur();

var Bulldog = function (nom = "RTP", dangereux = false) {
    Chien.call(this, nom);
};
    Bulldog.prototype = Object.create( Chien.prototype);

    Bulldog.prototype.constructor = Bulldog;

    Bulldog.prototype.getDangereux = function (dangereux){
        this.dangereux = dangereux;
    };

    Bulldog.prototype.getDangereux = function(){
        return this.dangereux;
    };

    var french = new Bulldog("Marcel");
    console.log(french.getNom());
    console.log(french.getDangereux());
    console.log(french instanceof Chien);

    //************************************************
separateur();

    var product = {
       name: "pommes",
       price: 4
    };

function afficher(tva){
    if (typeof(tva)=="undefined")
        console.log (this.name +" vaut "+ this.price);
    else
        console.log(this.name +" vaut "+ this.price*(1+tva));
    };

afficher.call(product);
afficher.call(product, 1.20);
afficher.call(product, [0.10]);
french.dangereux= "maman";//Attention
console.log(french.getDangereux());

    //************************************************
    //Encapsulation de membres de une Class
separateur();

var Personne = function (nom){
    var _nom = nom;
    return {
        getNom: function() {
            return _nom;
        }
    }
};
var lui = new Personne("lui");
console.log(lui.getNom());
console.log(lui instanceof Personne);//false
console.clear();
    //************************************************
    //Encapsulation de membres de une Class 
separateur();

var Lapin = (function(){
    var _nom;
    function Lapin(nom){
        _nom= nom;
    }

    Lapin.prototype.getNom= function() {
        return _nom;
    }

    Lapin.prototype.setNom = function(nom){
        if (typeof(nom)== "string") 
            _nom = nom;
        else
            throw "un joli nom SVP";
    }
    return Lapin;

}());

var pin = new Lapin("Pin");
console.log(pin.getNom());//Pin
console.log(pin instanceof Lapin);//True

Lapin.prototype.setNom= function(nom) {
   this.nom= nom;
}
pin.setNom("Fuck");
console.log(pin.getNom());//Pin
console.log(pin.nom);//Fuck
console.log(pin instanceof Lapin);//True

    //************************************************
    //Tableau 
separateur();


var tab= ["A","B"];

var table= {
    0: "A",
    1: "B"
}

console.log(tab[0]);
console.log(table[1]);

table[2]= "C";
console.log(table[2]);

tab[4]= "F";
tab["lapin"]= "Lapin";
console.log(tab);
console.log(tab.lapin);

separateur();

for (var i = 0; i < tab.length; i++) {
    console.log(tab[i]);
}

separateur()
    ;
for(var i in tab){
    console.log(tab[i]);
}

separateur();

console.log(tab.push("G","H"));
console.log(tab.shift());
console.log(tab.pop());
console.log(tab);
tab.splice(1,2,"Z");
separateur();

