using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_G15
{
    public partial class StaffForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableStaff = new DataTable();
        string str = @"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True";
        string placeholder = "Nhập số điện thoại...";
        private int offset;
        const int maxRowsPerPage = 15;
        public StaffForm()
        {
            InitializeComponent();
            offset = 0;
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            autoLoadStaffData();
            btnPrevious.Enabled = false;
            searchBox.Text = placeholder;
        }

        private void autoLoadStaffData()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "Exec ViewStaffListWith_n_Rows @offset ,@rows";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@offset", offset);
                command.Parameters.AddWithValue("@rows", maxRowsPerPage);
                adapter.SelectCommand = command;
                tableStaff.Clear();
                adapter.Fill(tableStaff);
                StaffDGV.DataSource = tableStaff;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.");
            }
        }

        private void StaffDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = StaffDGV.CurrentCell.RowIndex;
            tbID.Text = StaffDGV.Rows[rowIndex].Cells[0].Value.ToString();
            tbName.Text = StaffDGV.Rows[rowIndex].Cells[1].Value.ToString();
            tbPhone.Text = StaffDGV.Rows[rowIndex].Cells[2].Value.ToString();
            tbAddress.Text = StaffDGV.Rows[rowIndex].Cells[3].Value.ToString();
            tbEmail.Text = StaffDGV.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    if(tbID.Text == "")
                    {
                        MessageBox.Show("Hãy chọn nhân viên để xóa.");
                    }   
                    else
                    {

                        connection.Open();
                        SqlCommand checkStaffExisted = new SqlCommand("select * from NHANVIEN where MaNV = @MaNV", connection);
                        checkStaffExisted.Parameters.AddWithValue("@MaNV", tbID.Text);
                        SqlDataReader reader = checkStaffExisted.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Close();
                            DialogResult confirm = MessageBox.Show("Xác nhận xóa nhân viên này?", "Xóa Nhân Viên", MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                            {
                                SqlCommand DeleteNVCommand = new SqlCommand("Exec deleteNV @MANV, @SDT", connection);
                                DeleteNVCommand.Parameters.AddWithValue("@MANV", tbID.Text);
                                DeleteNVCommand.Parameters.AddWithValue("@SDT", tbPhone.Text);
                                DeleteNVCommand.ExecuteNonQuery();
                                tbID.Text = "";
                                tbName.Text = "";
                                tbPhone.Text = "";
                                tbEmail.Text = "";
                                tbAddress.Text = "";
                                autoLoadStaffData();
                                MessageBox.Show("Đã xóa Nhân viên!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên không tồn tại.");
                        }
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                    else
                    {
                        connection.Open();
                        SqlCommand checkStaffIfExisted = new SqlCommand("select MaNV from THONGTINCANHAN tt, NHANVIEN nv where tt.ID = nv.ID and tt.SoDienThoai = @SoDienThoai", connection);
                        checkStaffIfExisted.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                        SqlDataReader reader = checkStaffIfExisted.ExecuteReader();
                        if (!reader.HasRows)
                        {
                            reader.Close();
                            DialogResult confirm = MessageBox.Show("Xác nhận thêm nhân viên này?", "Thêm Nhân Viên", MessageBoxButtons.YesNo);
                            if (confirm == DialogResult.Yes)
                            {
                                //connection.Open();
                                SqlCommand InsertCommand = new SqlCommand("EXEC InsertNV @HoTen, @SDT,@DiaChi,@Email", connection);
                                InsertCommand.Parameters.AddWithValue("@HoTen", tbName.Text);
                                InsertCommand.Parameters.AddWithValue("@SDT", tbPhone.Text);
                                InsertCommand.Parameters.AddWithValue("@DiaChi", tbAddress.Text);
                                InsertCommand.Parameters.AddWithValue("@Email", tbEmail.Text);
                                InsertCommand.ExecuteNonQuery();
                                autoLoadStaffData();
                                MessageBox.Show("Nhân viên được thêm thành công.");
                                SqlCommand getStaffID = new SqlCommand("select MaNV from THONGTINCANHAN tt, NHANVIEN nv where tt.ID = nv.ID and tt.SoDienThoai = @SoDienThoai", connection);
                                getStaffID.Parameters.AddWithValue("@SoDienThoai", tbPhone.Text);
                                SqlDataReader reader2 = getStaffID.ExecuteReader();
                                tbID.Text = reader2.GetInt32(0).ToString();
                                reader2.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên đã tồn tại.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (searchBox.Text != placeholder && searchBox.Text != "")
            {
                command = connection.CreateCommand();
                command.CommandText = "Exec lookupNV_SDT @SDT";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@SDT", searchBox.Text);
                adapter.SelectCommand = command;
                tableStaff.Clear();
                adapter.Fill(tableStaff);
                StaffDGV.DataSource = tableStaff;
                searchBox.Text = placeholder;
            }
            else
            {
                MessageBox.Show("Hãy nhập số điện thoại.");
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                command = connection.CreateCommand();
                command.CommandText = "Exec lookupNV_SDT @SDT";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@SDT", searchBox.Text);
                adapter.SelectCommand = command;
                tableStaff.Clear();
                adapter.Fill(tableStaff);
                StaffDGV.DataSource = tableStaff;
                searchBox.Text = placeholder;
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (searchBox.Text == placeholder)
                searchBox.Text = "";
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
                searchBox.Text = placeholder;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=DBMS_ThucHanh_Nhom15;Integrated Security=True"))
            {
                try
                {
                    if (tbName.Text == "" || tbPhone.Text == "" || tbAddress.Text == "" || tbEmail.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                    else if(tbID.Text == "")
                    {
                        MessageBox.Show("Hãy chọn nhân viên để sửa.");
                    }    
                    else
                    {
                        DialogResult confirm = MessageBox.Show("Xác nhận sửa nhân viên này?", "Thêm Nhân Viên", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            connection.Open();
                            SqlCommand SaveCommand = new SqlCommand("exec updateNV @MaNV,@HoTen,@SDT,@DiaChi,@Email", connection);
                            SaveCommand.Parameters.AddWithValue("@MaNV", tbID.Text);
                            SaveCommand.Parameters.AddWithValue("@HoTen", tbName.Text);
                            SaveCommand.Parameters.AddWithValue("@SDT", tbPhone.Text);
                            SaveCommand.Parameters.AddWithValue("@DiaChi", tbAddress.Text);
                            SaveCommand.Parameters.AddWithValue("@Email", tbEmail.Text);
                            SaveCommand.ExecuteNonQuery();
                            autoLoadStaffData();
                            MessageBox.Show("Chỉnh sửa thông tin thành công.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            offset += 10;
            try
            {
                autoLoadStaffData();
                btnPrevious.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            offset -= 10;
            if (offset <= 0)
            {
                offset = 0;
                btnPrevious.Enabled = false;
            }
            autoLoadStaffData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            tbID.Text = "";
            tbName.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
            tbEmail.Text = "";
            offset = 0;
            autoLoadStaffData();
        }
    }
}
