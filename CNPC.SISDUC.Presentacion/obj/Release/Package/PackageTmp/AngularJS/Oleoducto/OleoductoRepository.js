var GetOleoductoUrl = '/api/wsducto/GetOleoductos';
var AddOleoductoUrl = '/api/wsducto/Post';
var UpdateOleoductoUrl = '/api/wsducto/Put';

app.factory('OleoductoRepository', function ($http) {
    return {
        get: function (parameterlist) {
            return $http.get(GetOleoductoUrl,
            {
                params: {
                    name: parameterlist.name,
                    page: parameterlist.page,
                    records: parameterlist.records
                }
            });
        },
        add: function (oleoducto) {
            return $http.post(AddOleoductoUrl, oleoducto);
        },
        delete: function (oleoducto) {
            return $http.delete(oleoductoUrl + oleoducto.id);
        },
        update: function (oleoducto) {
            return $http.put(UpdateOleoductoUrl, oleoducto);
        }
    };
});