$(document).ready(function () {
    ShowRoomData();
});

function ShowRoomData() {

    var url = $('#urlRoomData').val();

    $.ajax({
        url: '/Room/RoomList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id + '</td>';
                object += '<td>' + item.roomNumber + '</td>';
                object += '<td>' + item.type + '</td>';
                object += '<td>' + item.price + ' ₺</td>';
                object += '<td>' + (item.isAvailable ? "Boş" : "Dolu") + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.id + ')">Düzenle</a> || <a href="#" class="btn btn-danger" onclick="Delete(' + item.id + ');">Sil</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Odalar yüklenirken bir hata oluştu!");
        }
    });
}

$('#btnAddRoom').click(function () {
    ClearTextBox();
    $('#RoomModal').modal('show');
    $('#roomIdField').hide();
    $('#AddRoomBtn').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#roomHeading').text('Yeni Oda Ekle');
});


function AddRoom() {
    var objData = {
        RoomNumber: $('#RoomNumber').val(),
        Type: $('#Type').val(),
        Price: $('#Price').val(),
        IsAvailable: true 
    }
    $.ajax({
        url: '/Room/AddRoom',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Oda Kaydedildi');
            ClearTextBox();
            ShowRoomData();
            HideModalPopUp();
        },
        error: function () {
            alert("Oda kaydedilemedi!");
        }
    });
}

function Edit(id) {
    $.ajax({
        url: '/Room/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#RoomModal').modal('show');
            $('#RoomId').val(response.id);
            $('#RoomNumber').val(response.roomNumber);
            $('#Type').val(response.type);
            $('#Price').val(response.price);

            $('#AddRoomBtn').css('display', 'none');
            $('#btnUpdate').css('display', 'block');
            $('#roomHeading').text('Oda Bilgilerini Güncelle');
        },
        error: function () {
            alert('Oda verisi bulunamadı!');
        }
    });
}


function UpdateRoom() {
    var objData = {
        Id: $('#RoomId').val(),
        RoomNumber: $('#RoomNumber').val(),
        Type: $('#Type').val(),
        Price: $('#Price').val()
    }
    $.ajax({
        url: '/Room/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Oda Güncellendi');
            HideModalPopUp();
            ShowRoomData();
            ClearTextBox();
        },
        error: function () {
            alert("Oda güncellenemedi!");
        }
    });
}

function Delete(id) {
    if (confirm('Bu odayı silmek istediğinize emin misiniz?')) {
        $.ajax({
            url: '/Room/Delete?id=' + id,
            success: function () {
                alert('Oda Silindi!');
                ShowRoomData();
            },
            error: function () {
                alert("Oda silinirken hata oluştu!");
            }
        });
    }
}

function ClearTextBox() {
    $('#RoomNumber').val('');
    $('#Type').val('');
    $('#Price').val('');
    $('#RoomId').val('');
}

function HideModalPopUp() {
    $('#RoomModal').modal('hide');
}