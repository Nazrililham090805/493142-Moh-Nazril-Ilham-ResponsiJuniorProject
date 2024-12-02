# 493142-Moh-Nazril-Ilham-ResponsiJuniorProject

## Inisialisasi Table Database Dan Function

Kode berikut digunakan untuk membuat tabel `departemen` dan `karyawan`, serta menginisialisasi sequence untuk ID masing-masing tabel.

```sql
-- Membuat sequence untuk ID departemen
create sequence dep_id start 1;

-- Membuat tabel departemen
create table departemen(
    id_dep character varying primary key,
    nama_dep character varying (30)
);

-- Membuat sequence untuk ID karyawan
create sequence users_id start 1;

-- Membuat tabel karyawan
create table karyawan(
    id_karyawan character(6) default 'K'||nextval('users_id') primary key,
    nama varchar(30),
    id_dep character varying references departemen(id_dep)
);

-- Data Awal untuk Tabel departemen
insert into departemen(id_dep, nama_dep) values
('HR', 'HR'),
('ENG', 'Engineer'),
('DEV', 'Developer'),
('PM', 'Product Manager'),
('FIN', 'Finance');

--  Fungsi add_karyawan
CREATE OR REPLACE FUNCTION add_karyawan(
    in_nama text,
    in_id_dep character varying
)
RETURNS integer AS $$
DECLARE
    new_id_karyawan char(6);
BEGIN
    -- Membuat ID Karyawan baru menggunakan sequence
    new_id_karyawan := 'K' || nextval('users_id');
    
    -- Memeriksa apakah karyawan sudah ada
    IF EXISTS (
        SELECT 1 FROM karyawan
        WHERE id_karyawan = new_id_karyawan
    ) THEN
        RETURN 409; -- Karyawan sudah ada
    ELSE
        -- Menambahkan data karyawan
        INSERT INTO karyawan (id_karyawan, nama, id_dep)
        VALUES (new_id_karyawan, in_nama, in_id_dep);
        RETURN 201; -- Berhasil
    END IF;
END;
$$ LANGUAGE plpgsql;


-- Fungsi delete_karyawan
CREATE OR REPLACE FUNCTION delete_karyawan(
    in_id_karyawan char(6)
)
RETURNS INTEGER AS $$
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM karyawan
        WHERE id_karyawan = in_id_karyawan
    )
    THEN
        DELETE FROM karyawan
        WHERE id_karyawan = in_id_karyawan;
        RETURN 204; -- Berhasil dihapus
    ELSE
        RETURN 404; -- Tidak ditemukan
    END IF;
END;
$$ LANGUAGE plpgsql;

```





## Screenshots

### INSERT
![Screenshot](Asset/Screenshot%202024-12-02%20104402.png "Screenshot 2024-12-02")


Deskripsi: Gambar ini menunjukkan tampilan DATA BERHASIL DITAMBAHKAN.

---

### UPDATE
![Screenshot](Asset/Screenshot%202024-12-02%20104425.png "Screenshot 2024-12-02")


Deskripsi: Gambar ini menunjukkan tampilan DATA BERHASIL DIUPDATE.

---

### DELETE
![Screenshot](Asset/Screenshot%202024-12-02%20104436.png "Screenshot 2024-12-02")


Deskripsi: Gambar ini menunjukkan tampilan DATA BERHASIL DIHAPUS



