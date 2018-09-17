class Company extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div>
                <div>
                    Company: {this.props.name}
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
        this.state = {
            purchases: []
        }
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
        return <PieChart data={this.categorizePurchases()} />
        //return (this.state.purchases.map(e => <div className="row" key={e}><Company name={e} /></div>))
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
            'title': 'Your Spending',
            'width': 800,
            'height': 800,
            'colors': ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6'],
            'animation': { "startup": true }

        };

        // Instantiate and draw our chart, passing in some options.
        var chart = new google.visualization.PieChart(document.getElementById('app'));
        chart.draw(data, options);
    }

    render() {
        return '';
    }
}

ReactDOM.render(<PurchaseSummary />, document.getElementById('app'))
