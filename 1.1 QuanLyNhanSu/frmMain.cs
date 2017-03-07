using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1_QuanLyNhanSu
{
    public partial class frmMain : Form
    {
        public void getData()
        {
            try
            {
                SqlConnection kn = new SqlConnection(globalParemeter.connectionString);
                kn.Open();
                string sql = @"select nv.MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT,TenPB,TenTD,TenCV 
                                from tblNhanVien nv,tblHoSo hs,tblChucVu cv,tblPhongBan pb, tblTrinhDo td 
                                    where nv.MaNV = hs.MaNV and nv.MaCV = cv.MaCV and nv.MaPB = pb.MaPB and nv.MaTD = td.MaTD";
                SqlCommand command = new SqlCommand();
                SqlDataAdapter com = new SqlDataAdapter();
                dgvNhanVien.Columns.Clear();
                dgvNhanVien.AutoGenerateColumns = false;
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "MaNV";
                column.HeaderText = "Mã NV";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenNV";
                column.HeaderText = "Tên NV";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "GioiTinh";
                column.HeaderText = "Giới Tính";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "QueQuan";
                column.HeaderText = "Quê Quán";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "BaoHiemXH";
                column.HeaderText = "Mã BHXH";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "SoDT";
                column.HeaderText = "Số ĐT";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenPB";
                column.HeaderText = "Phòng Ban";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenTD";
                column.HeaderText = "Trình Độ";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TenCV";
                column.HeaderText = "Công Việc";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "TienCongMotNgay";
                column.HeaderText = "Mức Lương";
                dgvNhanVien.Columns.Add(column);
                column = new DataGridViewColumn();

                command = new SqlCommand(sql, kn);
                com = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                com.Fill(dt);
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu");
            }
            finally
            {
                SqlConnection con = new SqlConnection();
                con.Close();
            }
        }
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            getData();

            SqlConnection con = new SqlConnection(globalParemeter.connectionString);
            con.Open();

            string sql = "select * from tblPhongBan";
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter com = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            com.Fill(dt);
            cbbPhongBan.DataSource = dt;
            cbbPhongBan.DisplayMember = dt.Columns["TenPB"].ToString();
            cbbPhongBan.ValueMember = dt.Columns["MaPB"].ToString();

            sql = "select * from tblChucVu";
            command = new SqlCommand(sql, con);
            com = new SqlDataAdapter(command);
            dt = new DataTable();
            com.Fill(dt);
            cbbCongViec.DataSource = dt;
            cbbCongViec.DisplayMember = dt.Columns["TenCV"].ToString();
            cbbCongViec.ValueMember = dt.Columns["MaCV"].ToString();

            sql = "select * from tblTrinhDo";
            command = new SqlCommand(sql, con);
            com = new SqlDataAdapter(command);
            dt = new DataTable();
            com.Fill(dt);
            cbbTrinhDo.DataSource = dt;
            cbbTrinhDo.DisplayMember = dt.Columns["TenTD"].ToString();
            cbbTrinhDo.ValueMember = dt.Columns["MaTD"].ToString();

            con.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string gt = "";
                if (rbtnNam.Checked) gt = "Nam";
                else if (rbtnNu.Checked) gt = "Nu";
                string sql = @"insert into tblNhanVien(MaNV,MaCV,MaTD,MaPB) values ("+txtMaNV.Text+","+cbbCongViec.SelectedValue.ToString()+","+cbbTrinhDo.SelectedValue.ToString()+","+cbbPhongBan.SelectedValue.ToString()+")"+"\n"
                    + "insert into tblHoSo(MaNV,TenNV,GioiTinh,QueQuan,BaoHiemXH,SoDT) values ("+txtMaNV.Text+",'"+txtTenNV.Text+"','"+gt+"','"+txtQueQuan.Text+"','"+txtBaoHiemXH.Text+"','"+txtSDT.Text+"')";
                try
                {
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chưa thêm được");
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chưa Thêm được");
            }
            getData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string gt = "";
                if (rbtnNam.Checked) gt = "Nam";
                else if (rbtnNu.Checked) gt = "Nu";
                string sql = @"update tblNhanVien set MaPB="+cbbPhongBan.SelectedValue.ToString()+",MaCV="+cbbCongViec.SelectedValue.ToString()+",MaTD="+cbbTrinhDo.SelectedValue.ToString()+" where MaNV="+txtMaNV.Text + "\n"
                    + "update tblHoSo set TenNV='"+txtTenNV.Text+"',GioiTinh='"+gt+"',QueQuan='"+txtQueQuan.Text+"',BaoHiemXH='"+txtBaoHiemXH.Text+"',SoDT='"+txtSDT.Text+"' where MaNV="+txtMaNV.Text;
                try
                {
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chưa thêm được");
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chưa Thêm được");
            }
            getData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(globalParemeter.connectionString);
                con.Open();
                string gt = "";
                if (rbtnNam.Checked) gt = "Nam";
                else if (rbtnNu.Checked) gt = "Nu";
                string sql = @"delete tblHoSo where MaNV=" + txtMaNV.Text+"\n"+
                    "delete tblNhanVien where MaNV="+txtMaNV.Text;
                try
                {
                    SqlCommand command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chưa thêm được");
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chưa Thêm được");
            }
            getData();
        }
    }
}
