
var map = function(){
	emit( this._id, {count : this.comments.length})
};

var reduce = function(key, values){
	var rv = {
		news : key,
		count : 0,
	}
	values.forEach(function(value){
		rv.count += value.count;
	});
	return rv;
}

db.news.mapReduce(
		map,
		reduce,
		{ out: "commNum" });

var cursor = db.commNum.find({}).sort({value : -1});
var temp;
while(cursor.hasNext()){
	temp = cursor.next();
	printjson(temp.value)
	printjson(db.news.findOne({ _id: temp._id},{_id:0, image:0}));

}
