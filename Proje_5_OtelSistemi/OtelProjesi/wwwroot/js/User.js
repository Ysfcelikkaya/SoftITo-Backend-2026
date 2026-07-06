$(document).ready(function () {
    ShowUserData();
});

function ShowUserData() {
    $.ajax({
        url: '/User/UserList',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json;charset=utf-8;',
        success: function (result) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.id + '</td>';
                object += '<td>' + item.fullName + '</td>';
                object += '<td>' + item.email + '</td>';
                object += '<td>' + item.phoneNumber + '</td>';
                object += '<td><a href="#" class="btn btn-primary" onclick="Edit(' + item.id + ')">Düzenle</a> || <a href="#" class="btn btn-danger" onclick="Delete(' + item.id + ');">Sil</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Kullanıcılar yüklenirken bir hata oluştu!");
        }
    });
}

$('#btnAddUser').click(function () {
    ClearTextBox();
    $('#UserModal').modal('show');
    $('#AddUserBtn').css('display', 'block');
    $('#btnUpdate').css('display', 'none');
    $('#userHeading').text('Yeni Kullanıcı Ekle');
});

function AddUser() {
    var objData = {
        FullName: $('#FullName').val(),
        Email: $('#Email').val(),
        PhoneNumber: $('#PhoneNumber').val()
    }
    $.ajax({
        url: '/User/AddUser',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Kullanıcı Kaydedildi');
            ClearTextBox();
            ShowUserData();
            HideModalPopUp();
        },
        error: function () {
            alert("Kullanıcı kaydedilemedi!");
        }
    });
}

function Edit(id) {
    $.ajax({
        url: '/User/Edit?id=' + id,
        type: 'Get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#UserModal').modal('show');
            $('#UserId').val(response.id);
            $('#FullName').val(response.fullName);
            $('#Email').val(response.email);
            $('#PhoneNumber').val(response.phoneNumber);

            $('#AddUserBtn').css('display', 'none');
            $('#btnUpdate').css('display', 'block');
            $('#userHeading').text('Kullanıcı Bilgilerini Güncelle');
        },
        error: function () {
            alert('Kullanıcı verisi bulunamadı!');
        }
    });
}

function UpdateUser() {
    var objData = {
        Id: $('#UserId').val(),
        FullName: $('#FullName').val(),
        Email: $('#Email').val(),
        PhoneNumber: $('#PhoneNumber').val()
    }
    $.ajax({
        url: '/User/Update',
        type: 'Post',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert('Kullanıcı Güncellendi');
            HideModalPopUp();
            ShowUserData();
            ClearTextBox();
        },
        error: function () {
            alert("Kullanıcı güncellenemedi!");
        }
    });
}

function Delete(id) {
    if (confirm('Bu kullanıcıyı silmek istediğinize emin misiniz?')) {
        $.ajax({
            url: '/User/Delete?id=' + id,
            success: function () {
                alert('Kullanıcı Silindi!');
                ShowUserData();
            },
            error: function () {
                alert("Kullanıcı silinirken hata oluştu!");
            }
        });
    }
}

function ClearTextBox() {
    $('#UserId').val('');
    $('#FullName').val('');
    $('#Email').val('');
    $('#PhoneNumber').val('');
}

function HideModalPopUp() {
    $('#UserModal').modal('hide');
}