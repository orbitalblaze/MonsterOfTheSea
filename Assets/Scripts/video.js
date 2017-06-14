// Add this script to any game object in your scene (preferably your Main Camera)

// Attach the same 6 videos you used in your skybox to the 6 slots of this array
var movies : MovieTexture[] = new MovieTexture[6];

// As your scene starts, this script will then iterate through those videos
// and set them to loop and make them start playing
function Start(){
    for (var movie in movies) {
        movie.loop = true;
        movie.Play();
    }
}