var movies : MovieTexture[] = new MovieTexture[6];

function Start () {
	for (var movie in movies) {
		movie.loop = true;
		movie.Play();
	}
}