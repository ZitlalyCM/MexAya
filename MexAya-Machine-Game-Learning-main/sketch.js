let xibalba;
let uImg;
let tImg;
let bImg;
let Arrows = [];
let soundClassifier;




function preload(){
  const options = { probabilityThreshold: 0.95 };

  soundClassifier = ml5.soundClassifier('SpeechCommands18w',options);
  uImg = loadImage("xilbaba.gif");
  tImg = loadImage("train.jpg");
  bImg = loadImage("background.png");
  
}


 function mousePressed(){
   Arrows.push(new Arrow());
 }

function setup() {
  createCanvas(600, 450);
  xibalba = new Xibalba();
  soundClassifier.classify(gotCommand);
  button = createButton('Jugar de nuevo');
  button.position(0, 0);
  button.mousePressed(lup);
 
}
function lup(){
  loop();

}

function gotCommand(error, results){
  if(error){
    console.error(error);
  }
  console.log(results[0].label, results[0].confidence);
  if(results[0].label=='up'){
    xibalba.jump();
  }
}

function keyPressed(){
  if(key == ' '){
    xibalba.jump();
  }
}

function draw() {
  if (random(1)<0.005){
   Arrows.push(new Arrow());
 }
  

  
  background(bImg);
  
    
  for(let a of Arrows){
    a.move();
    a.show();
    if(xibalba.hits(a)){
      console.log('Game Over');
      noLoop();
      
    
  }
  }
   
  xibalba.show();
  xibalba.move();
  

  
}