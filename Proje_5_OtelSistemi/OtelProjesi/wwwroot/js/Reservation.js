$(document).ready(function () {
    ShowReservationData();
    LoadRooms();
    LoadUsers();
});

function ShowReservationData() {
    $.ajax({
        url: '/Reservation/ReservationList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id + '</td>';
                object += '<td>Oda ' + item.roomNumber + '</td>';
                object += '<td>' + item.userFullName + '</td>';
                object += '<td>' + item.checkInDate + '</td>';
                object += '<td>' + item.checkOutDate + '</td>';
                object += '<td>' + item.totalPrice + ' ₺</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.id + ')">Düzenle</a> || <a href="#" class="btn btn-danger" onclick="Delete(' + item.id + ');">Sil/İptal</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Rezervasyonlar yüklenemedi!");
        }
    });
}

function LoadRooms() {
    $.ajax({
        url: '/Room/RoomList',
        type: 'Get',
        success: function (res) {
            var html = '<option value="">Oda Seçiniz</option>';
            $.each(res, function (i, item) {
                if (item.isAvailable) { 
                    html += '<option value="' + item.id + '">Oda ' + item.roomNumber + ' (' + item.price + ' TL)</option>';
                }
            });
            $('#RoomId').html(html);
        }
    });
}

function LoadUsers() {
    $.ajax({
        url: '/User/UserList',
        type: 'Get',
        success: function (res) {
            var html = '<option value="">Müşteri Seçiniz</option>';
            $.each(res, function (i, item) {
                html += '<option value="' + item.id + '">' + item.fullName + '</option>';
            });
            $('#UserId').html(html);
        }
    });
}

$('#btnAddReservation').click(function () {
    ClearTextBox();
    LoadRooms(); 
    $('#ReservationModal').modal('show');
    $('#AddReservationBtn').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#resHeading').text('Yeni Rezervasyon Oluştur');
});

function AddReservation() {
    var objData = {
        RoomId: $('#RoomId').val(),
        UserId: $('#UserId').val(),
        CheckInDate: $('#CheckInDate').val(),
        CheckOutDate: $('#CheckOutDate').val()
    }
    $.ajax({
        url: '/Reservation/AddReservation',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Rezervasyon Başarıyla Kaydedildi');
            ClearTextBox();
            ShowReservationData();
            HideModalPopUp();
        },
        error: function () {
            alert("Kayıt esnasında hata oluştu!");
        }
    });
}

function Edit(id) {
    $.ajax({
        url: '/Reservation/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#ReservationModal').modal('show');
            $('#ReservationId').val(response.id);
            $('#RoomId').val(response.roomId);
            $('#UserId').val(response.userId);

            $('#CheckInDate').val(response.checkInDate.split('T')[0]);
            $('#CheckOutDate').val(response.checkOutDate.split('T')[0]);

            $('#AddReservationBtn').css('display', 'none');
            $('#btnUpdate').css('display', 'block');
            $('#resHeading').text('Rezervasyon Güncelle');
        }
    });
}

function UpdateReservation() {
    var objData = {
        Id: $('#ReservationId').val(),
        RoomId: $('#RoomId').val(),
        UserId: $('#UserId').val(),
        CheckInDate: $('#CheckInDate').val(),
        CheckOutDate: $('#CheckOutDate').val()
    }
    $.ajax({
        url: '/Reservation/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Rezervasyon Güncellendi');
            HideModalPopUp();
            ShowReservationData();
            ClearTextBox();
        }
    });
}

function Delete(id) {
    if (confirm('Bu rezervasyonu iptal etmek istiyor musunuz? (Oda tekrar boşa çıkacaktır)')) {
        $.ajax({
            url: '/Reservation/Delete?id=' + id,
            success: function () {
                alert('Rezervasyon İptal Edildi!');
                ShowReservationData();
            }
        });
    }
}

function ClearTextBox() {
    $('#ReservationId').val('');
    $('#RoomId').val('');
    $('#UserId').val('');
    $('#CheckInDate').val('');
    $('#CheckOutDate').val('');
}

function HideModalPopUp() {
    $('#ReservationModal').modal('hide');
}