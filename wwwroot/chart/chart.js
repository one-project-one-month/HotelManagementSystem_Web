window.setColumnChartRoomType = function () {

    var options = {
        series: [{
            name: 'Single Room',
            data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
        }, {
            name: 'Double Room',
            data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
        }, {
            name: 'Twin Room',
            data: [35, 41, 36, 26, 45, 48, 52, 53, 41]
        }],
        chart: {
            type: 'bar',
            height: 280
        },
        plotOptions: {
            bar: {
                horizontal: false,
                columnWidth: '55%',
                borderRadius: 5,
                borderRadiusApplication: 'end'
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        xaxis: {
            categories: ['Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
        },
        yaxis: {
            title: {
                text: 'Booking Count'
            }
        },
        fill: {
            opacity: 1
        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return val + " Booked"
                }
            }
        }
    };

    var chart = new ApexCharts(document.querySelector("#ColumnChartRoomType"), options);
    chart.render();

}
window.setLineChartSale = function () {
    var options = {
        series: [{
            name: "Sale $",
            data: [1000, 4500, 5600, 5100, 4700, 6200, 6900, 9100, 14800]
        }],
        chart: {
            height: 280,
            type: 'line',
            zoom: {
                enabled: false
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'straight'
        },

        grid: {
            row: {
                colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                opacity: 0.5
            },
        },
        yaxis: {
            title: {
                text: 'Monthly Sales - ($)'
            }
        },
        xaxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep'],
        }
    };

    var chart = new ApexCharts(document.querySelector("#LineChartSale"), options);
    chart.render();

}
window.setPieChartSourcesBooking = function () {
    var options = {
        series: [70,100,30],
        chart: {
            width: 380,
            type: 'pie',
        },
        labels: ['Mobile', 'Website', 'Walk In'],
        responsive: [{
            breakpoint: 480,
            options: {
                chart: {
                    width: 200
                },
                legend: {
                    position: 'bottom'
                }
            }
        }]
    };

    var chart = new ApexCharts(document.querySelector("#pieChartSourcesBooking"), options);
    chart.render();
}

window.setBarChartCount = function () {
    var options = {
        series: [{
            data: [44, 55, 41, 64]
        }],
        chart: {
            type: 'bar',
            height: 280
        },
        plotOptions: {
            bar: {
                horizontal: true,
                dataLabels: {
                    position: 'top',
                },
            }
        },
        dataLabels: {
            enabled: true,
            offsetX: -15,
            style: {
                fontSize: '15px',
                colors: ['#fff'],
            }
        },
        stroke: {
            show: true,
            width: 1,
            colors: ['#fff']
        },
        tooltip: {
            shared: true,
            intersect: false
        },
        xaxis: {
            categories: ['Guest Count', 'Total Bookings', 'Reserved Bookings', 'Rooms Needing Cleaning'],
        }
    };

    var chart = new ApexCharts(document.querySelector("#barChartCount"), options);
    chart.render();

}