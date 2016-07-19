var GetCambioUrl = '/api/WSCambioTuberia/GetCambio';
var AddCambioUrl = '/api/WSCambio/Post';
var UpdateCambioUrl = '/api/WSCambio/Put';

app.factory('CambioRepository', function ($http) {
    return {
        get: function (parameterlist) {
            return $http.get(GetCambioUrl,
            {
                params: {
                    name: parameterlist.name,
                    page: parameterlist.page,
                    records: parameterlist.records
                }
            });
        },
        add: function (registro) {
            return $http.post(AddCambioUrl, registro);
        },
        //delete: function (oleoducto) {
        //    return $http.delete(oleoductoUrl + oleoducto.id);
        //},
        update: function (registro) {
            return $http.put(UpdateCambioUrl, registro);
        }
    };
});