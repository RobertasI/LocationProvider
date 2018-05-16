
function myMap() {
	
	var mapOptions = {
		center: new google.maps.LatLng(55, 25),
		zoom: 10,
		mapTypeId: google.maps.MapTypeId.HYBRID
	}
	map = new google.maps.Map(document.getElementById("map"), mapOptions);

}


function addMarker(timeStamp, long, lat) {
	//var infowindow = new google.maps.InfoWindow({
	//	content: String(timeStamp)
	//});

	marker = new google.maps.Marker({
		position: new google.maps.LatLng(lat, long),
		map: map
	});

	//marker.addListener('click', function () {
	//	infowindow.open(map, marker);
	//});
}

//getDataFromController();

//function addMarker(timeStamp, long, lat) {

//	var infowindow = new google.maps.InfoWindow({
//		content: String(timeStamp)
//	});

//	marker = new google.maps.Marker({
//		position: new google.maps.LatLng(lat, long),
//		map: map
//	});
//	marker.addListener('click', function () {
//		infowindow.open(map, marker);
//	});
//}


//function getDataFromController() {
//	var dataList = [];
//	$.ajax({
//		url: '/Map/GetDeviceData',
//		type: 'GET',
//		dataType: 'json',
//		success: function (data) {
//			// process the data coming back
//			$.each(data, function (index, item) {

//				addMarker(item.TimeStamp, item.Longitude, item.Latitude)

//				dataList.push({ time: item.TimeStamp, latitude: item.Latitude, longitude: item.Longitude })
//			});
//		},
//		error: function (xhr, ajaxOptions, thrownError) {
//			alert(xhr.status);
//			alert(thrownError);
//		}
//	});
//}