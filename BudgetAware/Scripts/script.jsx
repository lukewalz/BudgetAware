class Company extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div>
                <div className='card-body'>
                    Company: {this.props.name}
                </div>
            </div>
        )
    }
}

class RecentPurchases extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div className='card'>
                <div className='card-body'>
                    <div className='card-header'>
                        Recent Purchases
                    </div>
                    <div className='card-text'>
                        <ul>
                            {this.props.purchases.map(i => <li>{i}</li>)}
                        </ul>
                    </div>
                </div>
            </div>
        )

    }
}

class PurchaseSummary extends React.Component {
    constructor(props) {
        super(props);
        this.deserialize = this.deserialize.bind(this);
        this.categorizePurchases = this.categorizePurchases.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.state = {
            purchases: []
        }
    }

    handleClick() {
        let f = document.getElementById('addPurchases');
        f.style.display = "block";
    }

    categorizePurchases() {
        let clothesArray = [];
        let foodArray = [];
        let miscArray = [];
        let entertainmentArray = [];

        let clothesCost = 0;
        let foodCost = 0;
        let miscCost = 0;
        let entertainmentCost = 0;

        console.log(clothesCost);
        this.state.purchases.map(i => i.Category == 'Clothing' ? clothesArray.push(i.Cost) : '');
        this.state.purchases.map(i => i.Category == 'Food' ? foodArray.push(i.Cost) : '');
        this.state.purchases.map(i => i.Category == 'Misc' ? miscArray.push(i.Cost) : '');
        this.state.purchases.map(i => i.Category == 'Entertainment' ? entertainmentArray.push(i.Cost) : '');

        clothesArray.map(i => clothesCost = clothesCost + i);
        foodArray.map(i => foodCost = foodCost + i);
        miscArray.map(i => miscCost = miscCost + i);
        entertainmentArray.map(i => entertainmentCost = entertainmentCost + i);

        let r = [clothesCost, foodCost, miscCost, entertainmentCost];
        console.log(r);
        return r;

    }

    deserialize() {
        let text = document.getElementById('ContentPlaceHolder1_hiddenJsonPurchases')
        let value = JSON.parse(text.innerText);
        let purchaseArray = Array.from(value);
        purchaseArray.forEach(i => {
            this.state.purchases.push(i)
        });
    }

    render() {
        this.deserialize();
        return <div><RecentPurchases purchases={this.state.purchases.map(i => i.Company + '---' + i.Cost)} /> <PieChart data={this.categorizePurchases()} /><div className='btn btn-primary' onClick={this.handleClick}>Add Purchase</div><BudgetDiagram /> </div>
    }


}
class BudgetDiagram extends React.Component {
    constructor(props) {
        super(props);
        this.renderBudgetChart = this.renderBudgetChart.bind(this);
        this.componentDidMount = this.componentDidMount.bind(this);

    }
    componentDidMount() {
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(this.renderBudgetChart);
    }

    renderBudgetChart() {
        var data = new google.visualization.arrayToDataTable([
            ['Category', 'Budget','Spent'],
            ['Clothing', 500, 800],
            ['Food', 500, 700],
            ['Entertainment', 500, 600],
            ['Miscellaneous', 500, 700]
        ]);

        var options = {
            width: '100%',
            bars: 'horizontal', // Required for Material Bar Charts.
            series: {
                0: { axis: 'budget' }, // Bind series 0 to an axis named 'distance'.
                1: { axis: 'spent' } // Bind series 1 to an axis named 'brightness'.
            },
            axes: {
                x: {
                    distance: { label: 'parsecs' }, // Bottom x-axis.
                    brightness: { side: 'top', label: 'apparent magnitude' } // Top x-axis.
                }
            }
        }

        var chart = new google.charts.Bar(document.getElementById('bar'));
        console.log('thisfar');
        chart.draw(data, options);
    }

render() {
    return '';
}
}

class PieChart extends React.Component {
    constructor(props) {
        super(props);
        this.drawChart = this.drawChart.bind(this);
        this.componentDidMount = this.componentDidMount.bind(this);
    }

    componentDidMount() {
        // Load the Visualization API and the corechart package.
        google.charts.load('current', { 'packages': ['corechart'] });

        // Set a callback to run when the Google Visualization API is loaded.
        google.charts.setOnLoadCallback(this.drawChart);
    }

    drawChart() {
        // Create the data table.
        var data = new google.visualization.DataTable();

        data.addColumn('string', 'Category');
        data.addColumn('number', 'Cost');
        data.addRows([
            ['Clothing', this.props.data[0]],
            ['Food', this.props.data[1]],
            ['Entertainment', this.props.data[2]],
            ['Miscellanous', this.props.data[3]],
        ]);

        // Set chart options
        var options = {
            'width': '100%',
            'height': 300,
            'colors': ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6'],
        };

        // Instantiate and draw our chart, passing in some options.
        var chart = new google.visualization.PieChart(document.getElementById('pie'));
        chart.draw(data, options);
    }

    render() {
        return '';
    }
}

ReactDOM.render(<PurchaseSummary />, document.getElementById('app2'))
