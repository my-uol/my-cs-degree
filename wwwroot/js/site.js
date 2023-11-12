function calculateGrades(grades, weights) {
    grades = grades.map(grade => grade ?? 0);
    weights = weights.map(weight => weight ?? 1);

    const [gradeOne, gradeTwo, gradeThree, gradeFour, gradeFive, gradeSix, gradeSeven, gradeEight] = grades;
    const [weightOne, weightTwo, weightThree, weightFour, weightFive, weightSix, weightSeven, weightEight] = weights;

    let averageMidterm = ((gradeOne * weightOne) + (gradeTwo * weightTwo) + (gradeThree * weightThree) + (gradeFour * weightFour) + (gradeFive * weightFive) + (gradeSix * weightSix) + (gradeSeven * weightSeven) + (gradeEight * weightEight));
    let averageFinal = gradeSeven;
    let overallGrade = ((averageMidterm + averageFinal) / 2);

    document.getElementById("averageMidterm").innerHTML = averageMidterm.toFixed(2);
    document.getElementById("averageFinal").innerHTML = averageFinal.toFixed(2);
    document.getElementById("overallGrade").innerHTML = overallGrade.toFixed(2);

    function setGradeClass(elementId, grade) {
        let className = 'm-auto ';
        if (grade >= 40) {
            className += 'table-success';
        } else if (grade >= 35) {
            className += 'table-warning';
        } else {
            className += 'table-danger';
        }
        document.getElementById(elementId).className = className;
    }

    setGradeClass("overallGrade", overallGrade);
    setGradeClass("averageFinal", averageFinal);
    setGradeClass("averageMidterm", averageMidterm);
}

function triggerGradeCalculation() {
    let gradeIds = ["gradeOne", "gradeTwo", "gradeThree", "gradeFour", "gradeFive", "gradeSix", "gradeSeven", "gradeEight"];
    let weightIds = ["weightOne", "weightTwo", "weightThree", "weightFour", "weightFive", "weightSix", "weightSeven", "weightEight"];

    let grades = gradeIds.map(id => {
        let element = document.getElementById(id);
        return element ? parseInt(element.value) : 0;
    });

    let weights = weightIds.map(id => {
        let element = document.getElementById(id);
        return element ? parseFloat(element.innerHTML) : 0;
    });

    calculateGrades(grades, weights);
}
