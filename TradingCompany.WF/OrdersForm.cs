using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TradingCompany.BL.Interfaces;
using TradingCompany.DTO;
using System.Linq.Dynamic.Core;
using System.Linq;
using Unity;

namespace TradingCompany.WF
{
    public partial class OrdersForm : Form
    {
        private readonly IOrderManager _manager;
        private List<OrderDTO> _orders;
        public OrdersForm(IOrderManager manager)
        {
            InitializeComponent();

            _manager = manager;

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            _orders = _manager.GetUserOrders(Program.CurrentUserID);

            BindingList<OrderDTO> blOrders = new BindingList<OrderDTO>(_orders);
            bsOrders.DataSource = blOrders;

            var currOrder = bsOrders.Current;

            //dgvOrders.DataSource = _orders;
            dgvOrders.DataSource = bsOrders;
            bnOrders.BindingSource = bsOrders;
        }

        private void dgvOrders_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var propertyName = dgvOrders.Columns[e.ColumnIndex].DataPropertyName;
            _orders = _orders.OrderBy(o => o.GetType().GetProperty(propertyName).GetValue(o, null)).ToList();
            
            bsOrders.DataSource = new BindingList<OrderDTO>(_orders);

            dgvOrders.DataSource = bsOrders;
            bnOrders.BindingSource = bsOrders;
        }

        private void bsOrders_CurrentChanged(object sender, System.EventArgs e)
        {
            var curr = bsOrders.Current;
        }

        private void bsOrders_PositionChanged(object sender, System.EventArgs e)
        {
            var curr = bsOrders.Current;
        }

        private void btAddReview_Click(object sender, System.EventArgs e)
        {
            Program.CurrenOrder = bsOrders.Current as OrderDTO;

            ReviewForm reviewForm = Program.Container.Resolve<ReviewForm>();

            var res = reviewForm.ShowDialog();
        }

        private void bnRepeatOrderButton_Click(object sender, System.EventArgs e)
        {
            OrderDTO selectedOrder = bsOrders.Current as OrderDTO;

            var message = $"Confirm order: Product: {selectedOrder.Product.ProductName} Price: {selectedOrder.Product.Price} Quantity: {selectedOrder.Quantity}";
            var response = MessageBox.Show(message, "Order", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                var success = _manager.CreateOrder(selectedOrder);

                RefreshGrid();
            }
        }
    }
}
