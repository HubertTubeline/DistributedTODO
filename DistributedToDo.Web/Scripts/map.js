function initMap() {

    var point = new google.maps.LatLng(array[0].GeoLat, array[0].GeoLong)
    var map = new google.maps.Map(document.getElementById('map'), {
        center: point,
        zoom: 6
    });
    for (var i = 0; i < array.length; i++) {
        var point = new google.maps.LatLng(array[i].GeoLat, array[i].GeoLong);
        var marker = new google.maps.Marker({
            position: point,
            map: map,
            label: array[i].Label,
            title: "" + i
        });
    }
}

function initMapEdit() {
    var marker = new google.maps.Marker({ position: center });
    var point = new google.maps.LatLng(document.getElementById('geoLat').value,
        document.getElementById('geoLong').value);
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 16,
        center: point
    });

    // This event listener calls addMarker() when the map is clicked.
    google.maps.event.addListener(map, 'click', function (event) {
        marker.setMap(null);
        marker = new google.maps.Marker({
            position: event.latLng,
        });
        marker.setMap(map);
        document.getElementById('geoLat').value = event.latLng.lat();
        document.getElementById('geoLong').value = event.latLng.lng();
    });

    // Add a marker at the center of the map.
    marker = new google.maps.Marker({
        position: point,
        map: map
    });
}

function initMapCreate() {
    var center = new google.maps.LatLng(35, 0);
    var marker = new google.maps.Marker({ position: center });
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 2,
        center: center
    });
    // This event listener calls addMarker() when the map is clicked.
    google.maps.event.addListener(map, 'click', function (event) {
        marker.setMap(null);
        marker = new google.maps.Marker({
            position: event.latLng,
        });
        marker.setMap(map);
        document.getElementById('geoLat').value = event.latLng.lat();
        document.getElementById('geoLong').value = event.latLng.lng();
    });
}