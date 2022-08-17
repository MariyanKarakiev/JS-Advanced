function check(x1, y1, x2, y2) {
    let P1to0 = [x1, y1, 0, 0];
    let P2to0 = [x2, y2, 0, 0];
    let P1toP2 = [x1, y1, x2, y2];

    let distances = [P1to0, P2to0, P1toP2];

    distances.forEach(element => {

        let distance = getDistance(element);

        if (Number.isInteger(distance)) {
            console.log(`{${element[0]}, ${element[1]}} to {${element[2]}, ${element[3]}} is valid`);
        }
        else {
            console.log(`{${element[0]}, ${element[1]}} to {${element[2]}, ${element[3]}} is invalid`);
        }

    });

    function getDistance(points) {

        let x1 = points[0];
        let y1 = points[1];
        let x2 = points[2];
        let y2 = points[3];

        return Math.sqrt(Math.pow((x2 - x1), 2) + (Math.pow((y2 - y1), 2)))
    }
}

check(3, 0, 0, 4);