
var map = function() {
	var words = this.text.split(/[\s,\.]+/);
	var wordCount = {};
	var wordKey = "";
	if(words){
		for (var i = 0; i < words.length; i++){
			wordKey = words[i];
			wordCount[wordKey] = (wordCount[wordKey] || 0) + 1;
		}
	}
	//printjson(wordCount);
	emit(this.author, wordCount);
};

var reduce = function(key, values){
	var wordCount = {};

	// key value pairs where key is a word and value is number of time it is used by a given author
	values.forEach(function(value){
		for(var wordKey in value){
			wordCount[wordKey] = (wordCount[wordKey] || 0) + value[wordKey];
		}
	});
	return wordCount;
};

var fin = function(key, reducedVal){
	var words = [];
	var wordObj;
	for(var temp in reducedVal){
		wordObj = { word: temp, count : reducedVal[temp]};
		words.push(wordObj);
	}
	words.sort(function(a,b){
		return b.count - a.count;});

	var finalWords = []
	counter = 0;
	while(counter < 10  && counter < words.length){
		finalWords.push(words[counter])
		counter++;
	}
	return finalWords;
};

db.news.mapReduce(map, reduce, { out: "mr2test6", finalize: fin});
var cursor = db.mr2test5.find({});
while(cursor.hasNext()){
	printjson(cursor.next());
}